using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    using System;
    using System.Windows.Forms;
    using PhumlaKamnandi.PresentationLayer;

    // Main MDI container form that hosts all other forms
    public partial class MDIParent : Form
    {
        private ToolStrip toolStrip;
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;

        public MDIParent()
        {
            InitializeComponent();
            SetupMDI();
            CreateMenuStrip();
            CreateToolStrip();
            CreateStatusBar();
        }

        private void SetupMDI()
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Phumla Kamnandi Hotels - Guest Reservation System";
            this.BackColor = System.Drawing.Color.LightGray;
        }
        private void CreateMenuStrip()
        {
            menuStrip = new MenuStrip();

            // Home Menu
            ToolStripMenuItem homeMenu = new ToolStripMenuItem("Home");
            homeMenu.Click += (s, e) => ShowHomePage();

            // New Booking Menu
            ToolStripMenuItem bookingMenu = new ToolStripMenuItem("New Booking");
            bookingMenu.Click += (s, e) => ShowNewBooking();

            // List Bookings Menu
            ToolStripMenuItem listMenu = new ToolStripMenuItem("List Bookings");
            listMenu.Click += (s, e) => ShowSearchBookings();

            // Reports Menu
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");

            ToolStripMenuItem occupancyReport = new ToolStripMenuItem("Occupancy Report");
            occupancyReport.Click += (s, e) => ShowOccupancyReport();

            ToolStripMenuItem accountReport = new ToolStripMenuItem("Account Status Report");
            accountReport.Click += (s, e) => ShowAccountStatusReport();

            reportsMenu.DropDownItems.Add(occupancyReport);
            reportsMenu.DropDownItems.Add(accountReport);

            // User Menu
            ToolStripMenuItem userMenu = new ToolStripMenuItem(SessionManager.GetUsername());

            ToolStripMenuItem logoutItem = new ToolStripMenuItem("Logout");
            logoutItem.Click += (s, e) => Logout();

            userMenu.DropDownItems.Add(logoutItem);

            // Add all menus
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(bookingMenu);
            menuStrip.Items.Add(listMenu);
            menuStrip.Items.Add(reportsMenu);
            menuStrip.Items.Add(userMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void CreateToolStrip()
        {
            toolStrip = new ToolStrip();
            toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);

            ToolStripButton homeButton = new ToolStripButton("Home");
            homeButton.Click += (s, e) => ShowHomePage();

            ToolStripButton newBookingButton = new ToolStripButton("New Booking");
            newBookingButton.Click += (s, e) => ShowNewBooking();

            ToolStripButton searchButton = new ToolStripButton("Search Bookings");
            searchButton.Click += (s, e) => ShowSearchBookings();

            ToolStripButton reportsButton = new ToolStripButton("Reports");
            reportsButton.Click += (s, e) => ShowReportsMenu();

            toolStrip.Items.Add(homeButton);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(newBookingButton);
            toolStrip.Items.Add(searchButton);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(reportsButton);

            this.Controls.Add(toolStrip);
        }

        private void CreateStatusBar()
        {
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = $"Logged in as: {SessionManager.GetUsername()} | {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";

            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);

            // Update time every minute
            Timer timer = new Timer();
            timer.Interval = 60000; // 1 minute
            timer.Tick += (s, e) => {
                statusLabel.Text = $"Logged in as: {SessionManager.GetUsername()} | {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
            };
            timer.Start();
        }

        private void ShowHomePage()
        {
            CloseAllChildForms();
            MainForm homeForm = new MainForm();
            homeForm.MdiParent = this;
            homeForm.Dock = DockStyle.Fill;
            homeForm.Show();
        }

        private void ShowNewBooking()
        {
            NewBookingForm form = new NewBookingForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ShowSearchBookings()
        {
            SearchBookingsForm form = new SearchBookingsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ShowOccupancyReport()
        {
            OccupancyReportForm form = new OccupancyReportForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ShowAccountStatusReport()
        {
            AccountStatusReportForm form = new AccountStatusReportForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ShowReportsMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem occupancy = new ToolStripMenuItem("Occupancy Report");
            occupancy.Click += (s, e) => ShowOccupancyReport();

            ToolStripMenuItem account = new ToolStripMenuItem("Account Status Report");
            account.Click += (s, e) => ShowAccountStatusReport();

            menu.Items.Add(occupancy);
            menu.Items.Add(account);

            menu.Show(Cursor.Position);
        }

        private void Logout()
        {
            if (FormHelper.ShowConfirmation("Are you sure you want to logout?"))
            {
                SessionManager.Logout();
                CloseAllChildForms();
                this.Close();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void CloseAllChildForms()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}