using PhumlaKamnandi.BusinessLayer.Models;
using PhumlaKamnandi.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Controllers
{
    // Main controller for managing booking operations and business logic
    public class BookingController
    {
        private BookingRepository bookingRepo;    // Handles booking data operations
        private GuestRepository guestRepo;        // Handles guest data operations
        private RoomRepository roomRepo;          // Handles room data operations
        private HotelRepository hotelRepo;        // Handles hotel data operations
        private AccountRepository accountRepo;    // Handles account data operations

        // Constructor initializes all repository dependencies
        public BookingController()
        {
            bookingRepo = new BookingRepository();
            guestRepo = new GuestRepository();
            roomRepo = new RoomRepository();
            hotelRepo = new HotelRepository();
            accountRepo = new AccountRepository();
        }

        // Checks how many rooms are available for given dates
        public int CheckAvailability(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            return roomRepo.GetAvailableRoomCount(hotelId, checkIn, checkOut);
        }

        // Retrieves list of available rooms for given dates
        public List<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            return roomRepo.GetAvailableRooms(hotelId, checkIn, checkOut);
        }

        // Calculates total cost for a booking including seasonal rates
        public decimal CalculateBookingCost(int hotelId, DateTime checkIn, DateTime checkOut, int adults, int children)
        {
            Hotel hotel = hotelRepo.GetById(hotelId);
            if (hotel == null)
                throw new Exception("Hotel not found");

            int nights = (checkOut - checkIn).Days;
            if (nights <= 0)
                throw new Exception("Invalid date range");

            decimal totalCost = 0;

            // Calculate cost for each night individually
            for (DateTime date = checkIn; date < checkOut; date = date.AddDays(1))
            {
                decimal nightlyRate = SeasonalRate.CalculateRate(hotel.StandardRate, date);

                // Adult charges at full rate
                decimal adultCost = adults * nightlyRate;

                // Children charges at half rate (ages 5-16)
                decimal childCost = children * (nightlyRate * 0.5m);

                totalCost += adultCost + childCost;
            }

            return totalCost;
        }

        // Calculates required deposit amount (10% of total)
        public decimal CalculateDeposit(decimal totalAmount)
        {
            return Math.Round(totalAmount * 0.10m, 2);
        }

        // Creates a new booking with guest and account setup
        public int CreateBooking(Guest guest, Booking booking, int currentUserId)
        {
            // Validate booking dates
            if (booking.CheckOutDate <= booking.CheckInDate)
                throw new Exception("Check-out date must be after check-in date");

            if (booking.CheckInDate.Date < DateTime.Today)
                throw new Exception("Cannot book for past dates");

            // Validate guest count limits
            if (booking.TotalGuests > 4)
                throw new Exception("Maximum 4 guests per room");

            if (booking.AdultsCount < 1)
                throw new Exception("At least 1 adult required per booking");

            // Check if guest already exists in system
            Guest existingGuest = null;
            if (!string.IsNullOrEmpty(guest.Phone))
            {
                existingGuest = guestRepo.GetByPhone(guest.Phone);
            }

            if (existingGuest != null)
            {
                booking.GuestID = existingGuest.GuestID;  // Use existing guest
            }
            else
            {
                // Create new guest record
                booking.GuestID = guestRepo.Create(guest);
            }

            // Verify room availability
            var availableRooms = roomRepo.GetAvailableRooms(1, booking.CheckInDate, booking.CheckOutDate);
            if (availableRooms.Count == 0)
                throw new Exception("No rooms available for selected dates");

            // Assign first available room
            booking.RoomID = availableRooms[0].RoomID;

            // Set booking metadata
            booking.CreatedBy = currentUserId;
            booking.CreatedDate = DateTime.Now;
            booking.BookingStatus = "Confirmed";

            // Create booking record
            int bookingId = bookingRepo.Create(booking);

            // Create associated financial account
            Account account = new Account
            {
                BookingID = bookingId,
                AccountStatus = "Open",
                TotalCharges = booking.TotalAmount,
                TotalPayments = booking.DepositAmount ?? 0,
                CreatedDate = DateTime.Now
            };
            accountRepo.Create(account);

            return bookingId;
        }

        // Retrieves booking by its unique identifier
        public Booking GetBooking(int bookingId)
        {
            return bookingRepo.GetById(bookingId);
        }

        // Searches bookings by various criteria
        public List<Booking> SearchBookings(string bookingRef = null, string phone = null, string lastName = null, DateTime? checkInDate = null)
        {
            if (!string.IsNullOrEmpty(bookingRef))
            {
                // Parse booking ID from reference format: PKH-YYYY-0015
                string[] parts = bookingRef.Split('-');
                if (parts.Length == 3 && int.TryParse(parts[2], out int bookingId))
                {
                    var booking = bookingRepo.GetById(bookingId);
                    return booking != null ? new List<Booking> { booking } : new List<Booking>();
                }
            }

            if (!string.IsNullOrEmpty(phone))
            {
                return bookingRepo.GetByGuestPhone(phone);
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                return bookingRepo.GetByGuestLastName(lastName);
            }

            if (checkInDate.HasValue)
            {
                return bookingRepo.GetByCheckInDate(checkInDate.Value);
            }

            return new List<Booking>();  // Return empty list if no criteria provided
        }

        // Updates an existing booking
        public void ModifyBooking(Booking booking)
        {
            // Validate booking constraints
            if (booking.CheckOutDate <= booking.CheckInDate)
                throw new Exception("Check-out date must be after check-in date");

            if (booking.TotalGuests > 4)
                throw new Exception("Maximum 4 guests per room");

            bookingRepo.Update(booking);
        }

        // Cancels a booking
        public void CancelBooking(int bookingId)
        {
            Booking booking = bookingRepo.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");

            if (booking.BookingStatus == "Cancelled")
                throw new Exception("Booking already cancelled");

            bookingRepo.Cancel(bookingId);
        }

        // Generates occupancy report for a date range
        public DataTable GenerateOccupancyReport(int hotelId, DateTime fromDate, DateTime toDate)
        {
            if (toDate <= fromDate)
                throw new Exception("End date must be after start date");

            return bookingRepo.GetOccupancyReport(hotelId, fromDate, toDate);
        }

        // Generates report on account statuses
        public DataTable GenerateAccountStatusReport()
        {
            return bookingRepo.GetAccountStatusReport();
        }

        // Returns season name for a given date
        public string GetSeasonName(DateTime date)
        {
            Season season = SeasonalRate.GetSeason(date);
            return season.ToString();
        }

        // Returns seasonal rate for a hotel on specific date
        public decimal GetSeasonalRate(int hotelId, DateTime date)
        {
            Hotel hotel = hotelRepo.GetById(hotelId);
            if (hotel == null)
                throw new Exception("Hotel not found");

            return SeasonalRate.CalculateRate(hotel.StandardRate, date);
        }
    }
}