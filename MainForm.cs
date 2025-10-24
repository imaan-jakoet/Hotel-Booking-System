using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Main application dashboard with navigation to all features
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupMenuStrip();  // Create navigation menu
        }

        // Displays current user's username


        // Creates the main navigation menu
        private void SetupMenuStrip()
        {
            // Find existing menu strip or create new one
            MenuStrip menuStrip = this.Controls.OfType<MenuStrip>().FirstOrDefault();
            if (menuStrip == null)
            {
                menuStrip = new MenuStrip();
                this.Controls.Add(menuStrip);
                this.MainMenuStrip = menuStrip;
            }

            // Clear existing items
            menuStrip.Items.Clear();

            // Home menu item
            ToolStripMenuItem homeMenu = new ToolStripMenuItem("Home");
            homeMenu.Click += homeToolStripMenuItem_Click;

            // New Booking menu item
            ToolStripMenuItem newBookingMenu = new ToolStripMenuItem("New Booking");
            newBookingMenu.Click += newBookingToolStripMenuItem_Click;

            // List Bookings menu item
            ToolStripMenuItem listBookingsMenu = new ToolStripMenuItem("List Bookings");
            listBookingsMenu.Click += listBookingsToolStripMenuItem_Click;

            // Reports menu with dropdown items
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");

            ToolStripMenuItem occupancyReportItem = new ToolStripMenuItem("Occupancy Report");
            occupancyReportItem.Click += occupancyReportToolStripMenuItem_Click;

            ToolStripMenuItem accountStatusReportItem = new ToolStripMenuItem("Account Status Report");
            accountStatusReportItem.Click += accountStatusReportToolStripMenuItem_Click;

            reportsMenu.DropDownItems.Add(occupancyReportItem);
            reportsMenu.DropDownItems.Add(accountStatusReportItem);

            // Username display (right-aligned)
            ToolStripMenuItem usernameMenu = new ToolStripMenuItem(SessionManager.GetUsername());
            usernameMenu.Alignment = ToolStripItemAlignment.Right;

            // Add all menu items
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(newBookingMenu);
            menuStrip.Items.Add(listBookingsMenu);
            menuStrip.Items.Add(reportsMenu);
            menuStrip.Items.Add(usernameMenu);
        }

        // Menu event handlers
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Already on home page
        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewBookingForm();
        }

        private void listBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSearchBookingsForm();
        }

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupancyReportForm form = new OccupancyReportForm();
            form.ShowDialog();
        }

        private void accountStatusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountStatusReportForm form = new AccountStatusReportForm();
            form.ShowDialog();
        }

        // Action button event handlers
        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            OpenNewBookingForm();
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            OpenSearchBookingsForm();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            OpenReportsMenu();
        }

        // Navigation methods
        private void OpenNewBookingForm()
        {
            NewBookingForm form = new NewBookingForm();
            form.ShowDialog();
        }

        private void OpenSearchBookingsForm()
        {
            SearchBookingsForm form = new SearchBookingsForm();
            form.ShowDialog();
        }

        // Shows context menu with report options
        private void OpenReportsMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem occupancyItem = new ToolStripMenuItem("Occupancy Report");
            occupancyItem.Click += (s, e) => {
                OccupancyReportForm form = new OccupancyReportForm();
                form.ShowDialog();
            };

            ToolStripMenuItem accountItem = new ToolStripMenuItem("Account Status Report");
            accountItem.Click += (s, e) => {
                AccountStatusReportForm form = new AccountStatusReportForm();
                form.ShowDialog();
            };

            menu.Items.Add(occupancyItem);
            menu.Items.Add(accountItem);
            menu.Show(Cursor.Position);
        }
    }
}