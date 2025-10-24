using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a payment transaction for a guest account
    public class Payment
    {
        public int PaymentID { get; set; }           // Unique identifier for the payment
        public int AccountID { get; set; }           // Reference to the account being paid
        public decimal PaymentAmount { get; set; }   // Amount of the payment
        public DateTime PaymentDate { get; set; }    // Date when payment was made
        public string PaymentMethod { get; set; }    // Payment method (Cash, Credit Card, etc.)
        public string PaymentReference { get; set; } // Reference number for the payment
        public int ProcessedBy { get; set; }         // ID of user who processed the payment

        // Default constructor sets initial values
        public Payment()
        {
            PaymentDate = DateTime.Now;     // Set to current date/time
            PaymentMethod = "Cash";         // Default payment method
        }
    }
}
