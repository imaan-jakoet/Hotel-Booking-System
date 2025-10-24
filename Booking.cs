using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a hotel room booking reservation
    public class Booking
    {
        public int BookingID { get; set; }               // Unique identifier for the booking
        public int GuestID { get; set; }                 // Reference to the guest
        public int RoomID { get; set; }                  // Reference to the room
        public DateTime CheckInDate { get; set; }        // Planned check-in date
        public DateTime CheckOutDate { get; set; }       // Planned check-out date
        public int AdultsCount { get; set; }             // Number of adult guests
        public int ChildrenCount { get; set; }           // Number of child guests
        public decimal TotalAmount { get; set; }         // Total cost of booking
        public decimal? DepositAmount { get; set; }      // Deposit paid (optional)
        public string BookingStatus { get; set; }        // Current status (Pending, Confirmed, etc.)
        public string SpecialRequirements { get; set; }  // Guest special requests
        public int CreatedBy { get; set; }               // User who created the booking
        public DateTime CreatedDate { get; set; }        // Date when booking was created
        public DateTime? ModifiedDate { get; set; }      // Last modification date (nullable)

        // Navigation properties for related entities
        public Guest Guest { get; set; }                 // Guest details
        public Room Room { get; set; }                   // Room details

        // Computed property generating booking reference number
        public string BookingReference => $"PKH-{CheckInDate.Year}-{BookingID:D4}";
        // Computed property calculating total nights stayed
        public int TotalNights => (CheckOutDate - CheckInDate).Days;
        // Computed property calculating total number of guests
        public int TotalGuests => AdultsCount + ChildrenCount;

        // Default constructor sets initial booking values
        public Booking()
        {
            BookingStatus = "Pending";       // New bookings start as pending
            CreatedDate = DateTime.Now;      // Set creation date to current time
            AdultsCount = 1;                // Default to 1 adult
            ChildrenCount = 0;              // Default to 0 children
        }
    }
}
