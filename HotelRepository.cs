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
    // Handles database operations for Hotel entities
    public class HotelRepository : BaseRepository
    {
        // Retrieves a hotel by its ID
        public Hotel GetById(int hotelId)
        {
            string query = "SELECT * FROM Hotels WHERE HotelID = @HotelID";
            SqlParameter[] parameters = { new SqlParameter("@HotelID", hotelId) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToHotel(dt.Rows[0]);

            return null;
        }

        // Retrieves all active hotels from the database
        public List<Hotel> GetAll()
        {
            string query = "SELECT * FROM Hotels WHERE IsActive = 1 ORDER BY HotelName";
            DataTable dt = ExecuteQuery(query);

            List<Hotel> hotels = new List<Hotel>();
            foreach (DataRow row in dt.Rows)
                hotels.Add(MapToHotel(row));

            return hotels;
        }

        // Maps a DataRow to a Hotel object
        private Hotel MapToHotel(DataRow row)
        {
            return new Hotel
            {
                HotelID = Convert.ToInt32(row["HotelID"]),
                HotelName = row["HotelName"].ToString(),
                Address = row["Address"].ToString(),
                Phone = row["Phone"].ToString(),
                Email = row["Email"].ToString(),
                LocationType = row["LocationType"].ToString(),
                TotalRooms = Convert.ToInt32(row["TotalRooms"]),
                StandardRate = Convert.ToDecimal(row["StandardRate"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}