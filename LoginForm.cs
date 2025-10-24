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
    // Handles user authentication and login process
    public partial class LoginForm : Form
    {
        private UserController userController;  // Handles user authentication

        public LoginForm()
        {
            InitializeComponent();
            userController = new UserController();
        }

        // Authenticates user credentials and logs them in
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    FormHelper.ShowError("Please enter username and password");
                    return;
                }

                // Authenticate user
                User user = userController.Login(username, password);
                SessionManager.CurrentUser = user;  // Store user session

                FormHelper.ShowSuccess($"Welcome, {user.FullName}!");

                // Open main application form
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        // Opens the user registration form
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        // Exits application when login form is closed
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form load event handler
        }
    }
}