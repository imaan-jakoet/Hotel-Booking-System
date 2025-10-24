using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Controllers
{
    // Provides static validation methods for various data types
    public static class ValidationHelper
    {
        // Validates email address format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Validates phone number format (minimum 10 digits)
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            // Remove common formatting characters
            phone = phone.Replace(" ", "").Replace("-", "");

            // Check if numeric and has reasonable length
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }

        // Validates credit card number format (13-19 digits)
        public static bool IsValidCreditCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            // Remove common formatting characters
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            // Check if numeric and length is 13-19 digits
            return cardNumber.Length >= 13 && cardNumber.Length <= 19 && cardNumber.All(char.IsDigit);
        }

        // Validates that check-out is after check-in and not in past
        public static bool IsValidDateRange(DateTime checkIn, DateTime checkOut)
        {
            return checkOut > checkIn && checkIn.Date >= DateTime.Today;
        }

        // Validates guest count constraints
        public static bool IsValidGuestCount(int adults, int children)
        {
            return adults >= 1 && adults <= 4 && children >= 0 && (adults + children) <= 4;
        }
    }
}
