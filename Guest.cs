using System;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a hotel guest with personal information
    public class Guest
    {
        public int GuestID { get; set; }         // Unique identifier for the guest
        public string FirstName { get; set; }    // Guest's first name
        public string LastName { get; set; }     // Guest's last name
        public string Email { get; set; }        // Contact email address
        public string Phone { get; set; }        // Contact phone number
        public string IDNumber { get; set; }     // Government-issued ID number
        public string GuestType { get; set; }    // Type of guest (Individual, Corporate, etc.)
        public DateTime CreatedDate { get; set; } // Date when guest record was created

        // Computed property returning full name
        public string FullName => $"{FirstName} {LastName}";

        // Default constructor sets initial values
        public Guest()
        {
            GuestType = "Individual";        // Default guest type
            CreatedDate = DateTime.Now;      // Set creation date to current time
        }
    }
}