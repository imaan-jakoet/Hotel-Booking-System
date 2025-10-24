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
    // Displays available rooms and pricing for selected dates
    public partial class RoomAvailabilityForm : Form
    {
        private BookingController bookingController;  // Handles booking operations
        private DateTime checkInDate;                 // Selected check-in date
        private DateTime checkOutDate;                // Selected check-out date
        private int adults;                           // Number of adult guests
        private int children;                         // Number of child guests
        private List<Room> availableRooms;           // List of available rooms
        private List<int> selectedRoomIds;           // IDs of selected rooms
        private decimal totalAmount;                  // Total booking cost
        private decimal depositAmount;                // Required deposit amount
        private int totalNights;                      // Total number of nights
        private decimal ratePerNight;                 // Rate per night
        private string season;                        // Current season

        // Constructor initializes form with booking parameters
        public RoomAvailabilityForm(DateTime checkIn, DateTime checkOut, int adultsCount, int childrenCount)
        {
            InitializeComponent();
            bookingController = new BookingController();
            selectedRoomIds = new List<int>();

            // Store booking parameters
            checkInDate = checkIn;
            checkOutDate = checkOut;
            adults = adultsCount;
            children = childrenCount;

            InitializeRoomList();  // Set up room selection UI
            LoadAvailability();    // Load available rooms and pricing
        }

        // Creates room selection list if not present
        private void InitializeRoomList()
        {
            // If you have a ListBox for room selection (add one if not present)
            // lstAvailableRooms should be added to your form
            if (this.Controls.Find("lstAvailableRooms", true).Length == 0)
            {
                ListBox lstRooms = new ListBox();
                lstRooms.Name = "lstAvailableRooms";
                lstRooms.Location = new System.Drawing.Point(30, 180);
                lstRooms.Size = new System.Drawing.Size(300, 120);
                lstRooms.SelectionMode = SelectionMode.MultiSimple;
                this.Controls.Add(lstRooms);

                Label lblRooms = new Label();
                lblRooms.Text = "Available Rooms (select one or more):";
                lblRooms.Location = new System.Drawing.Point(30, 160);
                lblRooms.Size = new System.Drawing.Size(300, 20);
                this.Controls.Add(lblRooms);
            }
        }

        // Loads available rooms and calculates pricing
        private void LoadAvailability()
        {
            try
            {
                // Get available rooms
                availableRooms = bookingController.GetAvailableRooms(1, checkInDate, checkOutDate);
                totalNights = (checkOutDate - checkInDate).Days;

                // Calculate costs for ONE room
                totalAmount = bookingController.CalculateBookingCost(1, checkInDate, checkOutDate, adults, children);
                depositAmount = bookingController.CalculateDeposit(totalAmount);

                // Get season info
                season = bookingController.GetSeasonName(checkInDate);
                ratePerNight = bookingController.GetSeasonalRate(1, checkInDate);

                // Update UI
                txtRoomsAvailable.Text = availableRooms.Count.ToString();
                txtTotalNights.Text = totalNights.ToString();
                txtSeason.Text = season;
                txtRatePerNight.Text = FormHelper.FormatCurrency(ratePerNight);
                txtTotalAmount.Text = FormHelper.FormatCurrency(totalAmount);
                txtTotalDeposit.Text = FormHelper.FormatCurrency(depositAmount);

                // Populate room list
                ListBox lstRooms = this.Controls.Find("lstAvailableRooms", true).FirstOrDefault() as ListBox;
                if (lstRooms != null)
                {
                    lstRooms.Items.Clear();
                    lstRooms.SelectionMode = SelectionMode.One; // Single selection for now

                    // Add each available room to the list
                    foreach (Room room in availableRooms)
                    {
                        lstRooms.Items.Add(new RoomListItem(room));
                    }

                    if (availableRooms.Count > 0)
                    {
                        lstRooms.SelectedIndex = 0; // Select first room by default
                    }

                    lstRooms.SelectedIndexChanged += lstAvailableRooms_SelectedIndexChanged;
                }

                if (availableRooms.Count == 0)
                {
                    btnBookRoom.Enabled = false;
                    FormHelper.ShowError("No rooms available for selected dates");
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Updates pricing when room selection changes
        private void lstAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lstRooms = sender as ListBox;
            if (lstRooms == null || lstRooms.SelectedItem == null) return;

            // Get selected room count
            int roomCount = lstRooms.SelectedItems.Count;
            if (roomCount == 0) roomCount = 1;

            // Recalculate costs based on number of rooms selected
            decimal singleRoomCost = bookingController.CalculateBookingCost(1, checkInDate, checkOutDate, adults, children);
            totalAmount = singleRoomCost * roomCount;
            depositAmount = bookingController.CalculateDeposit(totalAmount);

            // Update display
            txtTotalAmount.Text = FormHelper.FormatCurrency(totalAmount);
            txtTotalDeposit.Text = FormHelper.FormatCurrency(depositAmount);
        }

        // Proceeds to guest details form with selected room
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            ListBox lstRooms = this.Controls.Find("lstAvailableRooms", true).FirstOrDefault() as ListBox;

            if (lstRooms == null || lstRooms.SelectedItem == null)
            {
                FormHelper.ShowError("Please select a room");
                return;
            }

            if (availableRooms.Count > 0)
            {
                // Get selected room
                RoomListItem selectedItem = lstRooms.SelectedItem as RoomListItem;
                int selectedRoomId = selectedItem.Room.RoomID;

                // Open guest details form
                GuestDetailsForm form = new GuestDetailsForm(checkInDate, checkOutDate, adults, children,
                    totalAmount, depositAmount, selectedRoomId);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        // Returns to room selection without booking
        private void btnReturnToRoomSelection_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cancels the booking process
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (FormHelper.ShowConfirmation("Are you sure you want to cancel this booking?"))
            {
                this.Close();
            }
        }

        // Helper class to display rooms in ListBox with formatted text
        private class RoomListItem
        {
            public Room Room { get; set; }

            public RoomListItem(Room room)
            {
                Room = room;
            }

            // Formats room information for display
            public override string ToString()
            {
                return $"Room {Room.RoomNumber} - {Room.RoomType} (Max {Room.MaxOccupancy} guests)";
            }
        }
    }
}