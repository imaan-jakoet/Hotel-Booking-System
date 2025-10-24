using PhumlaKamnandi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhumlaKamnandi.PresentationLayer.Forms
{
    // Manages user session state throughout the application
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }  // Currently logged-in user

        // Checks if a user is currently logged in
        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        // Ends the current user session
        public static void Logout()
        {
            CurrentUser = null;
        }

        // Returns the current username or "Guest" if not logged in
        public static string GetUsername()
        {
            return CurrentUser?.Username ?? "Guest";
        }

        // Returns the current user ID or 0 if not logged in
        public static int GetUserId()
        {
            return CurrentUser?.UserID ?? 0;
        }
    }
}