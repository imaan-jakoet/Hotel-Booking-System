using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a hotel property with its details and pricing
    public class Hotel
    {
        public int HotelID { get; set; }          // Unique identifier for the hotel
        public string HotelName { get; set; }     // Name of the hotel
        public string Address { get; set; }       // Physical address
        public string Phone { get; set; }         // Contact phone number
        public string Email { get; set; }         // Contact email address
        public string LocationType { get; set; }  // Type of location (Urban, Resort, etc.)
        public int TotalRooms { get; set; }       // Total number of rooms in hotel
        public decimal StandardRate { get; set; } // Base room rate before seasonal adjustments
        public bool IsActive { get; set; }        // Whether hotel is operational

        // Default constructor sets initial hotel values
        public Hotel()
        {
            TotalRooms = 5;              // Default room count
            IsActive = true;              // Hotel is active by default
        }
    }
}