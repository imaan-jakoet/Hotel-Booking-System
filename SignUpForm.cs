using PhumlaKamnandi.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhumlaKamnandi.BusinessLayer.Controllers;
using PhumlaKamnandi.BusinessLayer.Models;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Handles new user registration
    public partial class SignUpForm : Form
    {
        private UserController userController;  // Handles user operations

        public SignUpForm()
        {
            InitializeComponent();
            userController = new UserController();
        }

        // Validates and processes user registration
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (!FormHelper.ValidateRequiredFields(txtUsername, txtPassword, txtConfirmPassword,
                    txtFirstName, txtLastName))
                    return;

                // Validate password confirmation
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    FormHelper.ShowError("Passwords do not match");
                    return;
                }

                // Create new user object
                User user = new User
                {
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = txtPassword.Text, // Note: Should be hashed in production!
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Role = "Receptionist"
                };

                // Register user in system
                int userId = userController.Register(user);
                FormHelper.ShowSuccess("Account created successfully! Please login.");
                this.Close();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }
    }
}