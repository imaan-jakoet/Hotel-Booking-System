using System;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a system user with authentication credentials
    public class User
    {
        public int UserID { get; set; }           // Unique identifier for the user
        public string Username { get; set; }      // Login username
        public string PasswordHash { get; set; }  // Hashed password for security
        public string FirstName { get; set; }     // User's first name
        public string LastName { get; set; }      // User's last name
        public string Role { get; set; }          // User role (Receptionist, Manager, etc.)
        public bool IsActive { get; set; }        // Whether user account is active
        public DateTime CreatedDate { get; set; } // Date when user was created

        // Computed property returning full name
        public string FullName => $"{FirstName} {LastName}";

        // Default constructor sets initial user values
        public User()
        {
            IsActive = true;              // New users are active by default
            CreatedDate = DateTime.Now;   // Set creation date to current time
            Role = "Receptionist";        // Default role
        }
    }
}