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
    // Displays detailed booking information and allows modifications
    public partial class ViewBookingForm : Form
    {
        private BookingController bookingController;  // Handles booking operations
        private Booking booking;                      // The booking being viewed
        private bool isModifying = false;             // Tracks if form is in edit mode

        // Constructor loads booking by ID
        public ViewBookingForm(int bookingId)
        {
            InitializeComponent();
            bookingController = new BookingController();
            LoadBooking(bookingId);  // Load and display booking

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

            // Add menu items
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

                DisplayBooking();    // Show booking information
                SetFieldsReadOnly(true);  // Start in read-only mode
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Populates form controls with booking information
        private void DisplayBooking()
        {
            // Set form title with booking reference
            this.Text = $"Booking Details - {booking.BookingReference}";

            // Guest details
            txtGuestFullName.Text = booking.Guest.FullName;
            txtPhone.Text = booking.Guest.Phone;
            txtEmail.Text = booking.Guest.Email;
            txtNumberOfRooms.Text = "1";

            // Booking dates
            txtCheckInDate.Text = FormHelper.FormatDate(booking.CheckInDate);
            txtCheckOutDate.Text = FormHelper.FormatDate(booking.CheckOutDate);

            // Guest counts
            txtAdults.Text = booking.AdultsCount.ToString();
            txtChildren.Text = booking.ChildrenCount.ToString();

            // Financial information
            txtTotalAmount.Text = FormHelper.FormatCurrency(booking.TotalAmount);
            txtDepositPaid.Text = FormHelper.FormatCurrency(booking.DepositAmount ?? 0);
            txtPaymentDate.Text = booking.DepositAmount.HasValue ? FormHelper.FormatDate(booking.CreatedDate) : "Not Paid";

            // Status
            txtStatus.Text = booking.BookingStatus;
        }

        // Toggles form fields between read-only and editable modes
        private void SetFieldsReadOnly(bool readOnly)
        {
            txtAdults.ReadOnly = readOnly;
            txtChildren.ReadOnly = readOnly;
            // Add other fields as needed
        }

        // Toggles between view mode and edit mode, or saves changes
        private void btnModifyBooking_Click(object sender, EventArgs e)
        {
            if (!isModifying)
            {
                // Enable editing mode
                isModifying = true;
                SetFieldsReadOnly(false);
                btnModifyBooking.Text = "Save Changes";
                btnCancelBooking.Text = "Cancel Edit";
            }
            else
            {
                // Save changes mode
                try
                {
                    // Validate adult count
                    if (!int.TryParse(txtAdults.Text, out int adults) || adults < 1)
                    {
                        FormHelper.ShowError("Please enter valid number of adults");
                        return;
                    }

                    // Validate children count
                    if (!int.TryParse(txtChildren.Text, out int children) || children < 0)
                    {
                        FormHelper.ShowError("Please enter valid number of children");
                        return;
                    }

                    // Validate total guest count
                    if (adults + children > 4)
                    {
                        FormHelper.ShowError("Maximum 4 guests per room");
                        return;
                    }

                    // Update booking object
                    booking.AdultsCount = adults;
                    booking.ChildrenCount = children;

                    // Save changes to database
                    bookingController.ModifyBooking(booking);
                    FormHelper.ShowSuccess("Booking updated successfully");

                    // Return to view mode
                    isModifying = false;
                    SetFieldsReadOnly(true);
                    btnModifyBooking.Text = "Modify Booking";
                    btnCancelBooking.Text = "Cancel Booking";

                    LoadBooking(booking.BookingID); // Reload to show updated data
                }
                catch (Exception ex)
                {
                    FormHelper.ShowError(ex.Message);
                }
            }
        }

        // Handles cancel booking or cancel edit based on current mode
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (!isModifying)
            {
                // Cancel the booking (in view mode)
                if (FormHelper.ShowConfirmation("Are you sure you want to cancel this booking?"))
                {
                    try
                    {
                        bookingController.CancelBooking(booking.BookingID);
                        FormHelper.ShowSuccess("Booking cancelled successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowError(ex.Message);
                    }
                }
            }
            else
            {
                // Cancel editing (in edit mode)
                isModifying = false;
                SetFieldsReadOnly(true);
                btnModifyBooking.Text = "Modify Booking";
                btnCancelBooking.Text = "Cancel Booking";
                DisplayBooking(); // Restore original values
            }
        }

        // Closes the form and returns to previous screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}