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
    // Collects guest personal and payment information for booking
    public partial class GuestDetailsForm : Form
    {
        private BookingController bookingController;  // Handles booking operations
        private DateTime checkInDate;                 // Selected check-in date
        private DateTime checkOutDate;                // Selected check-out date
        private int adults;                           // Number of adult guests
        private int children;                         // Number of child guests
        private decimal totalAmount;                  // Total booking cost
        private decimal depositAmount;                // Required deposit amount
        private int selectedRoomId;                   // Selected room ID

        // Constructor initializes form with booking parameters
        public GuestDetailsForm(DateTime checkIn, DateTime checkOut, int adultsCount, int childrenCount,
            decimal total, decimal deposit, int roomId)
        {
            InitializeComponent();
            bookingController = new BookingController();

            // Store booking parameters
            checkInDate = checkIn;
            checkOutDate = checkOut;
            adults = adultsCount;
            children = childrenCount;
            totalAmount = total;
            depositAmount = deposit;
            selectedRoomId = roomId;
        }

        // Validates and processes guest information
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (!FormHelper.ValidateRequiredFields(txtFirstName, txtLastName, txtPhone,
                    txtCreditCard, txtExpiryDate))
                    return;

                // Validate email format if provided
                if (!string.IsNullOrEmpty(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text))
                {
                    FormHelper.ShowError("Please enter a valid email address");
                    return;
                }

                // Validate phone number format
                if (!ValidationHelper.IsValidPhone(txtPhone.Text))
                {
                    FormHelper.ShowError("Please enter a valid phone number");
                    return;
                }

                // Validate credit card number
                if (!ValidationHelper.IsValidCreditCard(txtCreditCard.Text))
                {
                    FormHelper.ShowError("Please enter a valid credit card number");
                    return;
                }

                // Show confirmation form with collected information
                BookingConfirmationForm form = new BookingConfirmationForm(
                    txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text,
                    checkInDate, checkOutDate, adults, children, totalAmount, depositAmount,
                    txtCreditCard.Text, txtExpiryDate.Text, selectedRoomId);

                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Cancels the booking process
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (FormHelper.ShowConfirmation("Are you sure you want to cancel?"))
            {
                this.Close();
            }
        }
    }
}