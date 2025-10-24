using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer.Models
{
    // Represents a hotel room with its properties and status
    public class Room
    {
        public int RoomID { get; set; }           // Unique identifier for the room
        public int HotelID { get; set; }          // Reference to the hotel
        public string RoomNumber { get; set; }    // Physical room number
        public string RoomType { get; set; }      // Type of room (Standard, Suite, etc.)
        public string RoomStatus { get; set; }    // Current status (Available, Occupied, etc.)
        public int MaxOccupancy { get; set; }     // Maximum guests allowed
        public bool IsActive { get; set; }        // Whether room is available for booking

        // Default constructor sets initial room values
        public Room()
        {
            RoomType = "Standard";        // Default room type
            RoomStatus = "Available";     // New rooms start as available
            MaxOccupancy = 4;            // Maximum 4 guests per room
            IsActive = true;              // Room is active by default
        }
    }
}