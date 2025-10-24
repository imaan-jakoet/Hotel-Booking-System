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
    // Form for searching and viewing existing bookings
    public partial class SearchBookingsForm : Form
    {
        private BookingController bookingController;

        public SearchBookingsForm()
        {
            InitializeComponent();
            bookingController = new BookingController();
            InitializeGrid();
        }

        // Sets up the data grid view for displaying search results
        private void InitializeGrid()
        {
            dgvSearchResults.AutoGenerateColumns = false;
            dgvSearchResults.Columns.Clear();
            dgvSearchResults.DataError += dgvSearchResults_DataError;
            dgvSearchResults.CellContentClick += dgvSearchResults_CellContentClick;

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingRef",
                HeaderText = "Booking Ref",
                Width = 120
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GuestName",
                HeaderText = "Guest Name",
                Width = 150
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CheckIn",
                HeaderText = "Check-in",
                Width = 100
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CheckOut",
                HeaderText = "Check-out",
                Width = 100
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                Width = 100
            });

            // Hidden column to store BookingID
            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingID",
                HeaderText = "BookingID",
                Visible = false
            });

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn
            {
                Name = "ViewAction",
                HeaderText = "Actions",
                Text = "View Booking",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dgvSearchResults.Columns.Add(btnView);
        }

        // Handles data errors in the grid view
        private void dgvSearchResults_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        // Performs booking search based on user criteria
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string bookingRef = txtBookingReference.Text.Trim();
                string phone = txtPhoneNumber.Text.Trim();
                string lastName = txtGuestLastName.Text.Trim();
                DateTime? checkInDate = dtpCheckInDate.Checked ? dtpCheckInDate.Value.Date : (DateTime?)null;

                var bookings = bookingController.SearchBookings(bookingRef, phone, lastName, checkInDate);

                if (bookings.Count == 0)
                {
                    FormHelper.ShowError("No bookings found matching search criteria");
                    dgvSearchResults.Rows.Clear();
                    return;
                }

                // Manually populate the grid to avoid formatting issues
                dgvSearchResults.Rows.Clear();

                foreach (Booking booking in bookings)
                {
                    int rowIndex = dgvSearchResults.Rows.Add();
                    DataGridViewRow gridRow = dgvSearchResults.Rows[rowIndex];

                    // Booking Reference
                    gridRow.Cells["BookingRef"].Value = booking.BookingReference;

                    // Guest Name
                    gridRow.Cells["GuestName"].Value = booking.Guest?.FullName ?? "";

                    // Check-in Date - Format as string
                    gridRow.Cells["CheckIn"].Value = booking.CheckInDate.ToString("dd/MM/yyyy");

                    // Check-out Date - Format as string
                    gridRow.Cells["CheckOut"].Value = booking.CheckOutDate.ToString("dd/MM/yyyy");

                    // Status
                    gridRow.Cells["Status"].Value = booking.BookingStatus;

                    // Hidden BookingID for retrieval
                    gridRow.Cells["BookingID"].Value = booking.BookingID;
                }

                FormHelper.ShowSuccess($"Found {bookings.Count} booking(s)");
            }
            catch (Exception ex)
            {
                FormHelper.ShowError("Error searching bookings: " + ex.Message);
            }
        }

        // Clears all search criteria and results
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookingReference.Clear();
            txtPhoneNumber.Clear();
            txtGuestLastName.Clear();
            dtpCheckInDate.Checked = false;
            dgvSearchResults.Rows.Clear();
        }

        // Handles click events on grid view cells, particularly the view button
        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if clicked on button column and valid row
            if (e.RowIndex < 0) return; // Header click

            if (dgvSearchResults.Columns[e.ColumnIndex].Name == "ViewAction")
            {
                try
                {
                    // Get BookingID from hidden column
                    object bookingIdValue = dgvSearchResults.Rows[e.RowIndex].Cells["BookingID"].Value;

                    if (bookingIdValue != null && int.TryParse(bookingIdValue.ToString(), out int bookingId))
                    {
                        ViewBookingForm form = new ViewBookingForm(bookingId);
                        FormManager.OpenForm(form);
                    }
                    else
                    {
                        FormHelper.ShowError("Could not retrieve booking information");
                    }
                }
                catch (Exception ex)
                {
                    FormHelper.ShowError($"Error opening booking: {ex.Message}");
                }
            }
        }
        // Closes the form and returns to home
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}