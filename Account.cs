using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a financial account for a booking
    public class Account
    {
        public int AccountID { get; set; }           // Unique identifier for the account
        public int BookingID { get; set; }           // Reference to the associated booking
        public string AccountStatus { get; set; }    // Current status (Open, Closed, etc.)
        public decimal TotalCharges { get; set; }    // Total charges accumulated
        public decimal TotalPayments { get; set; }   // Total payments received
        public decimal BalanceDue => TotalCharges - TotalPayments; // Calculated outstanding balance
        public DateTime CreatedDate { get; set; }    // Date when account was created
        public DateTime? ClosedDate { get; set; }    // Date when account was closed (nullable)

        // Default constructor initializes account with starting values
        public Account()
        {
            AccountStatus = "Open";          // New accounts start as open
            TotalCharges = 0;               // No charges initially
            TotalPayments = 0;              // No payments initially
            CreatedDate = DateTime.Now;      // Set creation date to current time
        }
    }
}
