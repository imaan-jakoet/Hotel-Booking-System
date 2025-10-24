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
    // Handles database operations for Guest entities
    public class GuestRepository : BaseRepository
    {
        // Creates a new guest record in the database
        public int Create(Guest guest)
        {
            string query = @"INSERT INTO Guests (FirstName, LastName, Email, Phone, IDNumber, GuestType, CreatedDate) 
                           VALUES (@FirstName, @LastName, @Email, @Phone, @IDNumber, @GuestType, @CreatedDate);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@FirstName", guest.FirstName),
                new SqlParameter("@LastName", guest.LastName),
                new SqlParameter("@Email", (object)guest.Email ?? DBNull.Value),
                new SqlParameter("@Phone", (object)guest.Phone ?? DBNull.Value),
                new SqlParameter("@IDNumber", (object)guest.IDNumber ?? DBNull.Value),
                new SqlParameter("@GuestType", guest.GuestType),
                new SqlParameter("@CreatedDate", guest.CreatedDate)
            };

            return (int)ExecuteScalar(query, parameters);
        }

        // Retrieves a guest by their ID
        public Guest GetById(int guestId)
        {
            string query = "SELECT * FROM Guests WHERE GuestID = @GuestID";
            SqlParameter[] parameters = { new SqlParameter("@GuestID", guestId) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToGuest(dt.Rows[0]);

            return null;
        }

        // Retrieves a guest by their phone number
        public Guest GetByPhone(string phone)
        {
            string query = "SELECT * FROM Guests WHERE Phone = @Phone";
            SqlParameter[] parameters = { new SqlParameter("@Phone", phone) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToGuest(dt.Rows[0]);

            return null;
        }

        // Retrieves all guests from the database
        public List<Guest> GetAll()
        {
            string query = "SELECT * FROM Guests ORDER BY LastName, FirstName";
            DataTable dt = ExecuteQuery(query);

            List<Guest> guests = new List<Guest>();
            foreach (DataRow row in dt.Rows)
                guests.Add(MapToGuest(row));

            return guests;
        }

        // Updates an existing guest record
        public void Update(Guest guest)
        {
            string query = @"UPDATE Guests SET FirstName = @FirstName, LastName = @LastName, 
                           Email = @Email, Phone = @Phone, IDNumber = @IDNumber, GuestType = @GuestType 
                           WHERE GuestID = @GuestID";

            SqlParameter[] parameters = {
                new SqlParameter("@GuestID", guest.GuestID),
                new SqlParameter("@FirstName", guest.FirstName),
                new SqlParameter("@LastName", guest.LastName),
                new SqlParameter("@Email", (object)guest.Email ?? DBNull.Value),
                new SqlParameter("@Phone", (object)guest.Phone ?? DBNull.Value),
                new SqlParameter("@IDNumber", (object)guest.IDNumber ?? DBNull.Value),
                new SqlParameter("@GuestType", guest.GuestType)
            };

            ExecuteNonQuery(query, parameters);
        }

        // Maps a DataRow to a Guest object
        private Guest MapToGuest(DataRow row)
        {
            return new Guest
            {
                GuestID = Convert.ToInt32(row["GuestID"]),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,
                Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : null,
                IDNumber = row["IDNumber"] != DBNull.Value ? row["IDNumber"].ToString() : null,
                GuestType = row["GuestType"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}