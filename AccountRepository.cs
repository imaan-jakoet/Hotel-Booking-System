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
    // Handles database operations for Account entities
    public class AccountRepository : BaseRepository
    {
        // Creates a new account record in the database
        public int Create(Account account)
        {
            string query = @"INSERT INTO Accounts (BookingID, AccountStatus, TotalCharges, TotalPayments, CreatedDate)
                           VALUES (@BookingID, @AccountStatus, @TotalCharges, @TotalPayments, @CreatedDate);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@BookingID", account.BookingID),
                new SqlParameter("@AccountStatus", account.AccountStatus),
                new SqlParameter("@TotalCharges", account.TotalCharges),
                new SqlParameter("@TotalPayments", account.TotalPayments),
                new SqlParameter("@CreatedDate", account.CreatedDate)
            };

            return (int)ExecuteScalar(query, parameters);
        }

        // Retrieves an account by its associated booking ID
        public Account GetByBookingId(int bookingId)
        {
            string query = "SELECT * FROM Accounts WHERE BookingID = @BookingID";
            SqlParameter[] parameters = { new SqlParameter("@BookingID", bookingId) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToAccount(dt.Rows[0]);

            return null;
        }

        // Maps a DataRow to an Account object
        private Account MapToAccount(DataRow row)
        {
            return new Account
            {
                AccountID = Convert.ToInt32(row["AccountID"]),
                BookingID = Convert.ToInt32(row["BookingID"]),
                AccountStatus = row["AccountStatus"].ToString(),
                TotalCharges = Convert.ToDecimal(row["TotalCharges"]),
                TotalPayments = Convert.ToDecimal(row["TotalPayments"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                ClosedDate = row["ClosedDate"] != DBNull.Value ? Convert.ToDateTime(row["ClosedDate"]) : (DateTime?)null
            };
        }
    }
}
