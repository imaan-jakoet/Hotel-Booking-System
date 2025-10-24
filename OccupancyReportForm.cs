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
    // Generates and displays hotel occupancy reports for date ranges
    public partial class OccupancyReportForm : Form
    {
        private BookingController bookingController;  // Handles booking operations

        public OccupancyReportForm()
        {
            InitializeComponent();
            bookingController = new BookingController();
            InitializeDatePickers();  // Set up date constraints
            InitializeGrid();         // Configure data grid
        }

        // Sets up date picker default values and constraints
        private void InitializeDatePickers()
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today.AddDays(30);
            dtpFromDate.MaxDate = new DateTime(2025, 12, 31);
            dtpToDate.MaxDate = new DateTime(2025, 12, 31);
        }

        // Configures the data grid view for occupancy report
        private void InitializeGrid()
        {
            dgvReport.AutoGenerateColumns = false;  // Manual column configuration
            dgvReport.Columns.Clear();

            // Date column with formatting
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Date",
                DataPropertyName = "Date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Day of week column
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "Day", HeaderText = "Day", DataPropertyName = "Day", Width = 100 });

            // Season column
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "Season", HeaderText = "Season", DataPropertyName = "Season", Width = 80 });

            // Rate column with currency formatting
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rate",
                HeaderText = "Rate",
                DataPropertyName = "Rate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // Occupied rooms count
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "Occupied", HeaderText = "Occupied", DataPropertyName = "Occupied", Width = 80 });

            // Available rooms count
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { Name = "Available", HeaderText = "Available", DataPropertyName = "Available", Width = 80 });

            // Occupancy percentage with number formatting
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OccupancyPercent",
                HeaderText = "Occupancy %",
                DataPropertyName = "OccupancyPercent",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
        }

        // Generates and displays the occupancy report
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                // Validate date range
                if (toDate <= fromDate)
                {
                    FormHelper.ShowError("End date must be after start date");
                    return;
                }

                if ((toDate - fromDate).Days > 365)
                {
                    FormHelper.ShowError("Date range cannot exceed 365 days");
                    return;
                }

                // Get report data from controller
                DataTable reportData = bookingController.GenerateOccupancyReport(1, fromDate, toDate);

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    FormHelper.ShowError("No data available for the selected date range");
                    dgvReport.DataSource = null;
                    return;
                }

                dgvReport.DataSource = reportData;

                // Calculate summary statistics
                CalculateSummaryStatistics(reportData);

                // Update labels at bottom if they exist
                Control lblGenerated = this.Controls.Find("lblGeneratedDate", true).FirstOrDefault();
                if (lblGenerated is Label)
                    ((Label)lblGenerated).Text = "Generated: " + FormHelper.FormatDate(DateTime.Now);

                Control lblUser = this.Controls.Find("lblUser", true).FirstOrDefault();
                if (lblUser is Label)
                    ((Label)lblUser).Text = "User: " + SessionManager.GetUsername();

                FormHelper.ShowSuccess("Report generated successfully");
            }
            catch (Exception ex)
            {
                FormHelper.ShowError("Error generating report: " + ex.Message);
            }
        }

        // Calculates summary statistics from occupancy data
        private void CalculateSummaryStatistics(DataTable data)
        {
            try
            {
                if (data.Rows.Count == 0) return;

                decimal totalOccupancy = 0;
                decimal maxOccupancy = 0;
                decimal totalRevenue = 0;

                // Calculate totals and maximums
                foreach (DataRow row in data.Rows)
                {
                    decimal occupancy = row["OccupancyPercent"] != DBNull.Value ? Convert.ToDecimal(row["OccupancyPercent"]) : 0;
                    int occupied = row["Occupied"] != DBNull.Value ? Convert.ToInt32(row["Occupied"]) : 0;
                    decimal rate = row["Rate"] != DBNull.Value ? Convert.ToDecimal(row["Rate"]) : 0;

                    totalOccupancy += occupancy;
                    if (occupancy > maxOccupancy)
                        maxOccupancy = occupancy;

                    totalRevenue += occupied * rate;
                }

                decimal avgOccupancy = totalOccupancy / data.Rows.Count;

                // Update summary labels if they exist
                Control lblAvg = this.Controls.Find("lblAverageOccupancy", true).FirstOrDefault();
                if (lblAvg is Label)
                    ((Label)lblAvg).Text = $"{avgOccupancy:F2}%";

                Control lblPeak = this.Controls.Find("lblPeakOccupancy", true).FirstOrDefault();
                if (lblPeak is Label)
                    ((Label)lblPeak).Text = $"{maxOccupancy:F2}%";

                Control lblRevenue = this.Controls.Find("lblPeriodRevenue", true).FirstOrDefault();
                if (lblRevenue is Label)
                    ((Label)lblRevenue).Text = FormHelper.FormatCurrency(totalRevenue);
            }
            catch (Exception ex)
            {
                // Silently handle summary calculation errors
                Console.WriteLine($"Error calculating summary: {ex.Message}");
            }
        }

        // Closes the form and returns to home
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}