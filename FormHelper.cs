using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using PhumlaKamnandi.BusinessLayer;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Manages form navigation and maintains current form state
    public static class FormManager
    {
        private static Form currentForm;  // Currently active form

        // Opens a new form and closes the current one
        public static void OpenForm(Form newForm)
        {
            // Close current form if exists
            if (currentForm != null && !currentForm.IsDisposed)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            // Set and show new form
            currentForm = newForm;
            currentForm.FormClosed += (s, e) =>
            {
                if (currentForm == newForm)
                    currentForm = null;
            };

            currentForm.Show();
        }

        // Closes the currently active form
        public static void CloseCurrentForm()
        {
            if (currentForm != null && !currentForm.IsDisposed)
            {
                currentForm.Close();
                currentForm.Dispose();
                currentForm = null;
            }
        }

        // Returns the currently active form
        public static Form GetCurrentForm()
        {
            return currentForm;
        }
    }

    // Provides common form utility methods and operations
    public static class FormHelper
    {
        // Shows an error message dialog
        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Shows a success message dialog
        public static void ShowSuccess(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Shows a confirmation dialog with Yes/No buttons
        public static bool ShowConfirmation(string message, string title = "Confirm")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Validates that required fields are not empty
        public static bool ValidateRequiredFields(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    ShowError($"Please fill in all required fields.");
                    control.Focus();
                    return false;
                }
            }
            return true;
        }

        // Formats a decimal amount as currency string
        public static string FormatCurrency(decimal amount)
        {
            return $"R {amount:N2}";
        }

        // Formats a DateTime as date string
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        // Parses a date string to DateTime object
        public static DateTime? ParseDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime result))
                return result;
            return null;
        }
    }
}