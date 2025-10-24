using PhumlaKamnandi.BusinessLayer.Controllers;
using PhumlaKamnandi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Displays booking confirmation details before finalizing the booking
    public partial class BookingConfirmationForm : Form
    {
        private BookingController bookingController;  // Handles booking operations
        private string firstName;                     // Guest's first name
        private string lastName;                      // Guest's last name
        private string phone;                         // Guest's phone number
        private string email;                         // Guest's email address
        private DateTime checkInDate;                 // Planned check-in date
        private DateTime checkOutDate;                // Planned check-out date
        private int adults;                           // Number of adult guests
        private int children;                         // Number of child guests
        private decimal totalAmount;                  // Total booking cost
        private decimal depositAmount;                // Required deposit amount
        private string creditCard;                    // Credit card information
        private string expiryDate;                    // Card expiry date
        private int selectedRoomId;                   // Selected room ID

        // Constructor initializes form with booking details
        public BookingConfirmationForm(string fName, string lName, string ph, string em, DateTime checkIn, DateTime checkOut, int adultsCount, int childrenCount,
            decimal total, decimal deposit, string cc, string expiry, int roomId)
        {
            InitializeComponent();
            bookingController = new BookingController();

            // Store all booking parameters
            firstName = fName;
            lastName = lName;
            phone = ph;
            email = em;
            checkInDate = checkIn;
            checkOutDate = checkOut;
            adults = adultsCount;
            children = childrenCount;
            totalAmount = total;
            depositAmount = deposit;
            creditCard = cc;
            expiryDate = expiry;
            selectedRoomId = roomId;

            DisplayConfirmation();  // Show booking details
        }

        // Populates form controls with booking information
        private void DisplayConfirmation()
        {
            // Guest Details
            txtGuestName.Text = $"{firstName} {lastName}";
            txtGuestPhone.Text = phone;
            txtGuestEmail.Text = email;

            // Booking Details
            txtCheckInDate.Text = FormHelper.FormatDate(checkInDate);
            txtCheckOutDate.Text = FormHelper.FormatDate(checkOutDate);
            txtNumberOfNights.Text = ((checkOutDate - checkInDate).Days).ToString();
            txtGuests.Text = $"{adults} Adults, {children} Children";
            txtRatePerNight.Text = FormHelper.FormatCurrency(totalAmount / (checkOutDate - checkInDate).Days);
            txtRoomType.Text = "Standard";

            // Financial Summary
            txtAccommodationTotal.Text = FormHelper.FormatCurrency(totalAmount);
            txtDepositToPay.Text = FormHelper.FormatCurrency(depositAmount);
            txtBalanceDue.Text = FormHelper.FormatCurrency(totalAmount - depositAmount);
            txtTotalAmount.Text = FormHelper.FormatCurrency(totalAmount);
        }

        // Finalizes the booking and creates records in the system
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Create guest object
                Guest guest = new Guest
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    GuestType = "Individual"
                };

                // Create booking object with specific room
                Booking booking = new Booking
                {
                    RoomID = selectedRoomId,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    AdultsCount = adults,
                    ChildrenCount = children,
                    TotalAmount = totalAmount,
                    DepositAmount = depositAmount,
                    BookingStatus = "Confirmed"
                };

                // Create booking in database
                int bookingId = bookingController.CreateBooking(guest, booking, SessionManager.GetUserId());

                // Show booking summary
                BookingSummaryForm summaryForm = new BookingSummaryForm(bookingId);
                this.Hide();
                summaryForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Returns to room selection without confirming
        private void btnReturnToRoomSelection_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cancels the booking process
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (FormHelper.ShowConfirmation("Are you sure you want to cancel?"))
            {
                this.Close();
            }
        }
    }
}