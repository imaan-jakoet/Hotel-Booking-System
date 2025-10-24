using PhumlaKamnandi.BusinessLayer;
using PhumlaKamnandi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.DataLayer.Repositories
{
    // Handles database operations for Room entities
    public class RoomRepository : BaseRepository
    {
        // Retrieves available rooms for a hotel within a date range
        public List<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            string query = @"SELECT r.* FROM Rooms r
                           WHERE r.HotelID = @HotelID 
                           AND r.RoomStatus = 'Available' 
                           AND r.IsActive = 1
                           AND r.RoomID NOT IN (
                               SELECT RoomID FROM Bookings 
                               WHERE BookingStatus IN ('Confirmed', 'Pending')
                               AND (
                                   (CheckInDate <= @CheckOut AND CheckOutDate >= @CheckIn)
                               )
                           )";

            SqlParameter[] parameters = {
                new SqlParameter("@HotelID", hotelId),
                new SqlParameter("@CheckIn", checkIn),
                new SqlParameter("@CheckOut", checkOut)
            };

            DataTable dt = ExecuteQuery(query, parameters);
            List<Room> rooms = new List<Room>();

            foreach (DataRow row in dt.Rows)
                rooms.Add(MapToRoom(row));

            return rooms;
        }

        // Retrieves a room by its ID
        public Room GetById(int roomId)
        {
            string query = "SELECT * FROM Rooms WHERE RoomID = @RoomID";
            SqlParameter[] parameters = { new SqlParameter("@RoomID", roomId) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToRoom(dt.Rows[0]);

            return null;
        }

        // Returns the count of available rooms for a hotel within a date range
        public int GetAvailableRoomCount(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            var rooms = GetAvailableRooms(hotelId, checkIn, checkOut);
            return rooms.Count;
        }

        // Maps a DataRow to a Room object
        private Room MapToRoom(DataRow row)
        {
            return new Room
            {
                RoomID = Convert.ToInt32(row["RoomID"]),
                HotelID = Convert.ToInt32(row["HotelID"]),
                RoomNumber = row["RoomNumber"].ToString(),
                RoomType = row["RoomType"].ToString(),
                RoomStatus = row["RoomStatus"].ToString(),
                MaxOccupancy = Convert.ToInt32(row["MaxOccupancy"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}