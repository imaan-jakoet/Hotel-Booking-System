using PhumlaKamnandi.BusinessLayer.Controllers;
using PhumlaKamnandi.Data;
using PhumlaKamnandi.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Form for creating new hotel bookings with date and guest selection
    public partial class NewBookingForm : Form
    {
        private BookingController bookingController;  // Handles booking-related business logic
        private DateTime checkInDate;                 // Stores selected check-in date
        private DateTime checkOutDate;                // Stores selected check-out date
        private int adults;                           // Number of adult guests
        private int children;                         // Number of child guests

        public NewBookingForm()
        {
            InitializeComponent();
            bookingController = new BookingController();  // Create booking controller instance
            InitializeDatePickers();                      // Set up date picker constraints
            DisplayBookingInfo();                         // Show auto-generated booking info
        }

        // Sets up date picker controls with valid date ranges
        private void InitializeDatePickers()
        {
            dtpCheckIn.MinDate = DateTime.Today;          // Cannot book dates in the past
            dtpCheckIn.MaxDate = new DateTime(2025, 12, 31);  // Set maximum booking date
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);  // Check-out must be after today
            dtpCheckOut.MaxDate = new DateTime(2025, 12, 31);  // Same max date as check-in
        }

        // Displays auto-generated booking information that users cannot edit
        private void DisplayBookingInfo()
        {
            // Auto-display booking date (non-editable)
            Control txtBookingDate = this.Controls.Find("txtBookingDate", true).FirstOrDefault();
            if (txtBookingDate is TextBox)
            {
                ((TextBox)txtBookingDate).Text = FormHelper.FormatDate(DateTime.Now);  // Show current date
                ((TextBox)txtBookingDate).ReadOnly = true;  // User cannot modify booking date
            }

            // Auto-display booking reference placeholder (non-editable)
            Control txtBookingReference = this.Controls.Find("txtBookingReference", true).FirstOrDefault();
            if (txtBookingReference is TextBox)
            {
                ((TextBox)txtBookingReference).Text = "Will be generated after confirmation";  // Placeholder text
                ((TextBox)txtBookingReference).ReadOnly = true;  // User cannot modify reference
            }
        }

        // Updates check-out date constraints when check-in date changes
        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            // Ensure check-out date is always after check-in date
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }

        // Validates input and opens room availability form
        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            try
            {
                checkInDate = dtpCheckIn.Value.Date;    // Get selected check-in date
                checkOutDate = dtpCheckOut.Value.Date;  // Get selected check-out date

                // Validate number of adults (1-4)
                if (!int.TryParse(nudAdults.Text, out adults) || adults < 1 || adults > 4)
                {
                    FormHelper.ShowError("Please enter valid number of adults (1-4)");
                    return;
                }

                // Validate number of children (0 or more)
                if (!int.TryParse(nudChildren.Text, out children) || children < 0)
                {
                    FormHelper.ShowError("Please enter valid number of children (0 or more)");
                    return;
                }

                // Validate total guests don't exceed room capacity
                if (adults + children > 4)
                {
                    FormHelper.ShowError("Maximum 4 guests per room");
                    return;
                }

                // Validate date range is logical
                if (!ValidationHelper.IsValidDateRange(checkInDate, checkOutDate))
                {
                    FormHelper.ShowError("Invalid date range");
                    return;
                }

                // Open room availability form with selected criteria
                RoomAvailabilityForm form = new RoomAvailabilityForm(checkInDate, checkOutDate, adults, children);
                FormManager.OpenForm(form);  // Navigate to room selection
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);  // Show any unexpected errors
            }
        }

        // Resets all form fields to their default values
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            // Reset all form fields to default values
            nudAdults.Value = 0;                           // Reset adults to 0
            nudChildren.Value = 0;                         // Reset children to 0
            dtpCheckIn.Value = DateTime.Today;             // Reset to current date
            dtpCheckOut.Value = DateTime.Today.AddDays(1); // Reset to tomorrow
        }
    }
}