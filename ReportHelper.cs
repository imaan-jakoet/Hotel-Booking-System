using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Provides utility methods for exporting and printing reports
    public static class ReportHelper
    {
        // Exports DataGridView content to CSV file
        public static void ExportToCSV(DataGridView grid, string filename)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                // Write column headers
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    sb.Append(grid.Columns[i].HeaderText);
                    if (i < grid.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                // Write data rows
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;  // Skip the new row placeholder

                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        sb.Append(row.Cells[i].Value?.ToString() ?? "");
                        if (i < grid.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();
                }

                // Write to file
                System.IO.File.WriteAllText(filename, sb.ToString());
                FormHelper.ShowSuccess($"Report exported successfully to {filename}");
            }
            catch (Exception ex)
            {
                FormHelper.ShowError($"Error exporting report: {ex.Message}");
            }
        }

        // Placeholder for print functionality
        public static void PrintReport(DataGridView grid, string title)
        {
            FormHelper.ShowError("Print functionality not yet implemented.");
        }
    }
}