using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using PhumlaKamnandi.BusinessLayer.Models;

namespace PhumlaKamnandi.DataLayer.Repositories
{
    // Handles database operations for User entities and authentication
    public class UserRepository : BaseRepository
    {
        // Authenticates a user by username and password
        public User Authenticate(string username, string password)
        {
            // Simple password verification (in production, use proper hashing)
            string query = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @Password AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password) // Should be hashed in production
            };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToUser(dt.Rows[0]);

            return null;
        }

        // Creates a new user record in the database
        public int Create(User user)
        {
            string query = @"INSERT INTO Users (Username, PasswordHash, FirstName, LastName, Role, IsActive, CreatedDate)
                           VALUES (@Username, @PasswordHash, @FirstName, @LastName, @Role, @IsActive, @CreatedDate);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@IsActive", user.IsActive),
                new SqlParameter("@CreatedDate", user.CreatedDate)
            };

            return (int)ExecuteScalar(query, parameters);
        }

        // Retrieves a user by their ID
        public User GetById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapToUser(dt.Rows[0]);

            return null;
        }

        // Maps a DataRow to a User object
        private User MapToUser(DataRow row)
        {
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Role = row["Role"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}