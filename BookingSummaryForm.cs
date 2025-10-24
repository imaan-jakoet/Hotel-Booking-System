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
    // Displays a summary of a completed booking
    public partial class BookingSummaryForm : Form
    {
        private BookingController bookingController;  // Handles booking operations
        private Booking booking;                      // The booking being displayed

        // Constructor loads booking by ID
        public BookingSummaryForm(int bookingId)
        {
            InitializeComponent();
            bookingController = new BookingController();
            LoadBooking(bookingId);  // Load and display booking details

            // Set up navigation menu
            MenuStrip menuStrip = new MenuStrip();

            // Home menu item
            ToolStripMenuItem homeItem = new ToolStripMenuItem("Home");
            homeItem.Click += (s, e) => { MainForm form = new MainForm(); form.Show(); };

            // New Booking menu item
            ToolStripMenuItem bookingItem = new ToolStripMenuItem("New Booking");
            bookingItem.Click += (s, e) => { NewBookingForm form = new NewBookingForm(); form.Show(); };

            // List Bookings menu item
            ToolStripMenuItem listItem = new ToolStripMenuItem("List Bookings");
            listItem.Click += (s, e) => { SearchBookingsForm form = new SearchBookingsForm(); form.Show(); };

            // Reports menu with sub-items
            ToolStripMenuItem reportsItem = new ToolStripMenuItem("Reports");
            ToolStripMenuItem occupancySubItem = new ToolStripMenuItem("Occupancy Report");
            occupancySubItem.Click += (s, e) => { OccupancyReportForm form = new OccupancyReportForm(); form.Show(); };
            reportsItem.DropDownItems.Add(occupancySubItem);

            // Username display
            ToolStripMenuItem userItem = new ToolStripMenuItem(SessionManager.GetUsername());

            // Add all menu items
            menuStrip.Items.Add(homeItem);
            menuStrip.Items.Add(bookingItem);
            menuStrip.Items.Add(listItem);
            menuStrip.Items.Add(reportsItem);
            menuStrip.Items.Add(userItem);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        // Loads booking details from the database
        private void LoadBooking(int bookingId)
        {
            try
            {
                booking = bookingController.GetBooking(bookingId);
                if (booking == null)
                {
                    FormHelper.ShowError("Booking not found");
                    this.Close();
                    return;
                }

                DisplayBooking();  // Show booking information
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Populates form controls with booking information
        private void DisplayBooking()
        {
            // Guest Details
            txtName.Text = booking.Guest.FullName;
            txtPhone.Text = booking.Guest.Phone;
            txtEmail.Text = booking.Guest.Email;

            // Booking Details
            txtBookingReference.Text = booking.BookingReference;
            txtBookingDate.Text = FormHelper.FormatDate(booking.CreatedDate);
            txtStatusConfirmed.Text = booking.BookingStatus;

            // Accommodation Details
            txtCheckInDate.Text = FormHelper.FormatDate(booking.CheckInDate);
            txtCheckOutDate.Text = FormHelper.FormatDate(booking.CheckOutDate);
            txtNumberOfNights.Text = booking.TotalNights.ToString();
            txtGuests.Text = $"{booking.AdultsCount} Adults, {booking.ChildrenCount} Children";
            txtRatePerNight.Text = FormHelper.FormatCurrency(booking.TotalAmount / booking.TotalNights);
            txtRoomType.Text = "Standard";

            // Financial Summary
            txtAccommodation.Text = FormHelper.FormatCurrency(booking.TotalAmount);
            txtDepositToPay.Text = FormHelper.FormatCurrency(booking.DepositAmount ?? 0);
            txtBalanceDue.Text = FormHelper.FormatCurrency(booking.TotalAmount - (booking.DepositAmount ?? 0));
            txtTotalAmount.Text = FormHelper.FormatCurrency(booking.TotalAmount);
        }

        // Simulates sending confirmation email to guest
        private void btnEmail_Click(object sender, EventArgs e)
        {
            FormHelper.ShowSuccess("Confirmation email sent to " + booking.Guest.Email);
        }

        // Closes the summary form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}