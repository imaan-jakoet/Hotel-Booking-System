using PhumlaKamnandi.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Displays account status report with booking financial information
    public partial class AccountStatusReportForm : Form
    {
        private BookingController bookingController;
        private DataTable reportData;

        public AccountStatusReportForm()
        {
            InitializeComponent();
            bookingController = new BookingController();
            InitializeGrid();
            SetupMenuStrip();
        }

        // Creates the navigation menu strip for the form
        private void SetupMenuStrip()
        {
            MenuStrip menuStrip = this.Controls.OfType<MenuStrip>().FirstOrDefault();
            if (menuStrip == null)
            {
                menuStrip = new MenuStrip();
                this.Controls.Add(menuStrip);
                this.MainMenuStrip = menuStrip;
            }

            menuStrip.Items.Clear();

            ToolStripMenuItem homeMenu = new ToolStripMenuItem("Home");
            homeMenu.Click += (s, e) => FormManager.OpenForm(new MainForm());

            ToolStripMenuItem newBookingMenu = new ToolStripMenuItem("New Booking");
            newBookingMenu.Click += (s, e) => FormManager.OpenForm(new NewBookingForm());

            ToolStripMenuItem listBookingsMenu = new ToolStripMenuItem("List Bookings");
            listBookingsMenu.Click += (s, e) => FormManager.OpenForm(new SearchBookingsForm());

            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");
            ToolStripMenuItem occupancyItem = new ToolStripMenuItem("Occupancy Report");
            occupancyItem.Click += (s, e) => FormManager.OpenForm(new OccupancyReportForm());
            ToolStripMenuItem accountItem = new ToolStripMenuItem("Account Status Report");
            accountItem.Click += (s, e) => FormManager.OpenForm(new AccountStatusReportForm());
            reportsMenu.DropDownItems.Add(occupancyItem);
            reportsMenu.DropDownItems.Add(accountItem);

            ToolStripMenuItem usernameMenu = new ToolStripMenuItem(SessionManager.GetUsername());
            usernameMenu.Alignment = ToolStripItemAlignment.Right;

            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(newBookingMenu);
            menuStrip.Items.Add(listBookingsMenu);
            menuStrip.Items.Add(reportsMenu);
            menuStrip.Items.Add(usernameMenu);
        }

        // Sets up the data grid view columns for the report
        private void InitializeGrid()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();
            dgvReport.DataError += dgvReport_DataError;

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GuestName",
                HeaderText = "Guest Name",
                Width = 150
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingRef",
                HeaderText = "Booking Ref",
                Width = 120
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CheckIn",
                HeaderText = "Check-in",
                Width = 100
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalValue",
                HeaderText = "Total Value",
                Width = 100
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Deposit",
                HeaderText = "Deposit",
                Width = 100
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                Width = 100
            });

            dgvReport.CellContentClick += dgvReport_CellContentClick;
        }

        // Handles data errors in the grid view gracefully
        private void dgvReport_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        // Handles click events on grid view cells, particularly the view button
        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvReport.Columns["ViewBooking"].Index && e.RowIndex >= 0)
            {
                try
                {
                    string bookingRef = dgvReport.Rows[e.RowIndex].Cells["BookingRef"].Value?.ToString();

                    if (!string.IsNullOrEmpty(bookingRef))
                    {
                        string[] parts = bookingRef.Split('-');
                        if (parts.Length == 3 && int.TryParse(parts[2], out int bookingId))
                        {
                            ViewBookingForm viewForm = new ViewBookingForm(bookingId);
                            FormManager.OpenForm(viewForm);
                        }
                        else
                        {
                            FormHelper.ShowError("Invalid booking reference format");
                        }
                    }
                }
                catch (Exception ex)
                {
                    FormHelper.ShowError($"Error opening booking: {ex.Message}");
                }
            }
        }

        // Generates and displays the account status report
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                reportData = bookingController.GenerateAccountStatusReport();

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    FormHelper.ShowError("No account data available");
                    dgvReport.Rows.Clear();
                    return;
                }

                dgvReport.Rows.Clear();

                foreach (DataRow dataRow in reportData.Rows)
                {
                    int rowIndex = dgvReport.Rows.Add();
                    DataGridViewRow gridRow = dgvReport.Rows[rowIndex];

                    gridRow.Cells["GuestName"].Value = dataRow["GuestName"]?.ToString() ?? "";
                    gridRow.Cells["BookingRef"].Value = dataRow["BookingRef"]?.ToString() ?? "";

                    if (dataRow["CheckInDate"] != DBNull.Value)
                    {
                        DateTime checkInDate = Convert.ToDateTime(dataRow["CheckInDate"]);
                        gridRow.Cells["CheckIn"].Value = checkInDate.ToString("dd/MM/yyyy");
                    }

                    if (dataRow["TotalAmount"] != DBNull.Value)
                    {
                        decimal totalAmount = Convert.ToDecimal(dataRow["TotalAmount"]);
                        gridRow.Cells["TotalValue"].Value = totalAmount.ToString("C2");
                    }

                    if (dataRow["Deposit"] != DBNull.Value)
                    {
                        decimal deposit = Convert.ToDecimal(dataRow["Deposit"]);
                        gridRow.Cells["Deposit"].Value = deposit.ToString("C2");
                    }

                    gridRow.Cells["Status"].Value = dataRow["Status"]?.ToString() ?? "";
                }

                CalculateSummary(reportData);

                Control lblDate = this.Controls.Find("lblReportDate", true).FirstOrDefault();
                if (lblDate is Label)
                    ((Label)lblDate).Text = DateTime.Today.ToString("dd/MM/yyyy");

                FormHelper.ShowSuccess("Report generated successfully");
            }
            catch (Exception ex)
            {
                FormHelper.ShowError("Error generating report: " + ex.Message);
            }
        }

        // Calculates summary statistics from the report data
        private void CalculateSummary(DataTable data)
        {
            try
            {
                int totalAccounts = data.Rows.Count;
                decimal outstandingDeposits = 0;
                int overdueAccounts = 0;
                int confirmedBookings = 0;
                int pendingDeposits = 0;
                int corporateAccounts = 0;

                foreach (DataRow row in data.Rows)
                {
                    string status = row["Status"]?.ToString() ?? "";
                    decimal totalValue = row["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(row["TotalAmount"]) : 0;
                    decimal deposit = row["Deposit"] != DBNull.Value ? Convert.ToDecimal(row["Deposit"]) : 0;

                    if (status == "Confirmed")
                        confirmedBookings++;

                    if (deposit == 0)
                    {
                        pendingDeposits++;
                        outstandingDeposits += totalValue * 0.1m;
                    }

                    if (row["CheckInDate"] != DBNull.Value)
                    {
                        DateTime checkIn = Convert.ToDateTime(row["CheckInDate"]);
                        if (deposit == 0 && checkIn < DateTime.Today.AddDays(14))
                            overdueAccounts++;
                    }
                }

                SetTextBoxValue("txtTotalAccounts", totalAccounts.ToString());
                SetTextBoxValue("txtOutstandingDeposits", outstandingDeposits.ToString("C2"));
                SetTextBoxValue("txtOverdueAccounts", overdueAccounts.ToString());
                SetTextBoxValue("txtConfirmedBookings", confirmedBookings.ToString());
                SetTextBoxValue("txtPendingDeposits", pendingDeposits.ToString());
                SetTextBoxValue("txtCorporateAccounts", corporateAccounts.ToString());
                SetTextBoxValue("txtTotalOutstanding", outstandingDeposits.ToString("C2"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating summary: {ex.Message}");
            }
        }

        // Helper method to set text box values by control name
        private void SetTextBoxValue(string controlName, string value)
        {
            Control ctrl = this.Controls.Find(controlName, true).FirstOrDefault();
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = value;
        }

        // Navigates back to the home form
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            FormManager.OpenForm(new MainForm());
        }
    }
}