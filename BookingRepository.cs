using PhumlaKamnandi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhumlaKamnandi.BusinessLayer;

namespace PhumlaKamnandi.DataLayer.Repositories
{
    // Handles database operations for Booking entities
    public class BookingRepository : BaseRepository
    {
        // Creates a new booking record in the database
        public int Create(Booking booking)
        {
            string query = @"INSERT INTO Bookings (GuestID, RoomID, CheckInDate, CheckOutDate, 
                           AdultsCount, ChildrenCount, TotalAmount, DepositAmount, BookingStatus, 
                           SpecialRequirements, CreatedBy, CreatedDate) 
                           VALUES (@GuestID, @RoomID, @CheckInDate, @CheckOutDate, @AdultsCount, 
                           @ChildrenCount, @TotalAmount, @DepositAmount, @BookingStatus, 
                           @SpecialRequirements, @CreatedBy, @CreatedDate);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@GuestID", booking.GuestID),
                new SqlParameter("@RoomID", booking.RoomID),
                new SqlParameter("@CheckInDate", booking.CheckInDate),
                new SqlParameter("@CheckOutDate", booking.CheckOutDate),
                new SqlParameter("@AdultsCount", booking.AdultsCount),
                new SqlParameter("@ChildrenCount", booking.ChildrenCount),
                new SqlParameter("@TotalAmount", booking.TotalAmount),
                new SqlParameter("@DepositAmount", (object)booking.DepositAmount ?? DBNull.Value),
                new SqlParameter("@BookingStatus", booking.BookingStatus),
                new SqlParameter("@SpecialRequirements", (object)booking.SpecialRequirements ?? DBNull.Value),
                new SqlParameter("@CreatedBy", booking.CreatedBy),
                new SqlParameter("@CreatedDate", booking.CreatedDate)
            };

            return (int)ExecuteScalar(query, parameters);
        }

        // Retrieves a booking by its ID with guest and room details
        public Booking GetById(int bookingId)
        {
            string query = @"SELECT b.*, g.FirstName, g.LastName, g.Email, g.Phone, g.IDNumber, g.GuestType,
                           r.RoomNumber, r.RoomType, r.HotelID
                           FROM Bookings b
                           INNER JOIN Guests g ON b.GuestID = g.GuestID
                           INNER JOIN Rooms r ON b.RoomID = r.RoomID
                           WHERE b.BookingID = @BookingID";

            SqlParameter[] parameters = { new SqlParameter("@BookingID", bookingId) };
            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
                return MapToBooking(dt.Rows[0]);

            return null;
        }

        // Retrieves bookings by guest phone number
        public List<Booking> GetByGuestPhone(string phone)
        {
            string query = @"SELECT b.*, g.FirstName, g.LastName, g.Email, g.Phone, g.IDNumber, g.GuestType,
                           r.RoomNumber, r.RoomType, r.HotelID
                           FROM Bookings b
                           INNER JOIN Guests g ON b.GuestID = g.GuestID
                           INNER JOIN Rooms r ON b.RoomID = r.RoomID
                           WHERE g.Phone = @Phone
                           ORDER BY b.CheckInDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@Phone", phone) };
            DataTable dt = ExecuteQuery(query, parameters);

            List<Booking> bookings = new List<Booking>();
            foreach (DataRow row in dt.Rows)
                bookings.Add(MapToBooking(row));

            return bookings;
        }

        // Retrieves bookings by guest last name (partial match)
        public List<Booking> GetByGuestLastName(string lastName)
        {
            string query = @"SELECT b.*, g.FirstName, g.LastName, g.Email, g.Phone, g.IDNumber, g.GuestType,
                           r.RoomNumber, r.RoomType, r.HotelID
                           FROM Bookings b
                           INNER JOIN Guests g ON b.GuestID = g.GuestID
                           INNER JOIN Rooms r ON b.RoomID = r.RoomID
                           WHERE g.LastName LIKE @LastName
                           ORDER BY b.CheckInDate DESC";

            SqlParameter[] parameters = { new SqlParameter("@LastName", "%" + lastName + "%") };
            DataTable dt = ExecuteQuery(query, parameters);

            List<Booking> bookings = new List<Booking>();
            foreach (DataRow row in dt.Rows)
                bookings.Add(MapToBooking(row));

            return bookings;
        }

        // Retrieves bookings by specific check-in date
        public List<Booking> GetByCheckInDate(DateTime checkInDate)
        {
            string query = @"SELECT b.*, g.FirstName, g.LastName, g.Email, g.Phone, g.IDNumber, g.GuestType,
                           r.RoomNumber, r.RoomType, r.HotelID
                           FROM Bookings b
                           INNER JOIN Guests g ON b.GuestID = g.GuestID
                           INNER JOIN Rooms r ON b.RoomID = r.RoomID
                           WHERE b.CheckInDate = @CheckInDate
                           ORDER BY b.BookingID";

            SqlParameter[] parameters = { new SqlParameter("@CheckInDate", checkInDate) };
            DataTable dt = ExecuteQuery(query, parameters);

            List<Booking> bookings = new List<Booking>();
            foreach (DataRow row in dt.Rows)
                bookings.Add(MapToBooking(row));

            return bookings;
        }

        // Generates occupancy report for a hotel over a date range
        public DataTable GetOccupancyReport(int hotelId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
                WITH DateRange AS (
                    SELECT @FromDate AS ReportDate
                    UNION ALL
                    SELECT DATEADD(DAY, 1, ReportDate)
                    FROM DateRange
                    WHERE ReportDate < @ToDate
                )
                SELECT 
                    dr.ReportDate AS Date,
                    DATENAME(WEEKDAY, dr.ReportDate) AS Day,
                    CASE 
                        WHEN MONTH(dr.ReportDate) IN (12, 1, 4) THEN 'High'
                        WHEN MONTH(dr.ReportDate) IN (6, 7, 3, 10) THEN 'Mid'
                        ELSE 'Low'
                    END AS Season,
                    h.StandardRate * 
                    CASE 
                        WHEN MONTH(dr.ReportDate) IN (12, 1, 4) THEN 1.5
                        WHEN MONTH(dr.ReportDate) IN (6, 7, 3, 10) THEN 1.2
                        ELSE 1.0
                    END AS Rate,
                    COUNT(b.BookingID) AS Occupied,
                    h.TotalRooms - COUNT(b.BookingID) AS Available,
                    CAST(COUNT(b.BookingID) * 100.0 / h.TotalRooms AS DECIMAL(5,2)) AS OccupancyPercent
                FROM DateRange dr
                CROSS JOIN Hotels h
                LEFT JOIN Bookings b ON h.HotelID = (SELECT HotelID FROM Rooms WHERE RoomID = b.RoomID)
                    AND dr.ReportDate >= b.CheckInDate 
                    AND dr.ReportDate < b.CheckOutDate
                    AND b.BookingStatus IN ('Confirmed', 'Completed')
                WHERE h.HotelID = @HotelID
                GROUP BY dr.ReportDate, h.StandardRate, h.TotalRooms
                ORDER BY dr.ReportDate
                OPTION (MAXRECURSION 400)";

            SqlParameter[] parameters = {
                new SqlParameter("@HotelID", hotelId),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return ExecuteQuery(query, parameters);
        }

        // Updates an existing booking record
        public void Update(Booking booking)
        {
            string query = @"UPDATE Bookings SET CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate,
                           AdultsCount = @AdultsCount, ChildrenCount = @ChildrenCount, 
                           TotalAmount = @TotalAmount, DepositAmount = @DepositAmount,
                           BookingStatus = @BookingStatus, SpecialRequirements = @SpecialRequirements,
                           ModifiedDate = @ModifiedDate
                           WHERE BookingID = @BookingID";

            SqlParameter[] parameters = {
                new SqlParameter("@BookingID", booking.BookingID),
                new SqlParameter("@CheckInDate", booking.CheckInDate),
                new SqlParameter("@CheckOutDate", booking.CheckOutDate),
                new SqlParameter("@AdultsCount", booking.AdultsCount),
                new SqlParameter("@ChildrenCount", booking.ChildrenCount),
                new SqlParameter("@TotalAmount", booking.TotalAmount),
                new SqlParameter("@DepositAmount", (object)booking.DepositAmount ?? DBNull.Value),
                new SqlParameter("@BookingStatus", booking.BookingStatus),
                new SqlParameter("@SpecialRequirements", (object)booking.SpecialRequirements ?? DBNull.Value),
                new SqlParameter("@ModifiedDate", DateTime.Now)
            };

            ExecuteNonQuery(query, parameters);
        }

        // Cancels a booking by updating its status
        public void Cancel(int bookingId)
        {
            string query = @"UPDATE Bookings SET BookingStatus = 'Cancelled', ModifiedDate = @ModifiedDate
                           WHERE BookingID = @BookingID";

            SqlParameter[] parameters = {
                new SqlParameter("@BookingID", bookingId),
                new SqlParameter("@ModifiedDate", DateTime.Now)
            };

            ExecuteNonQuery(query, parameters);
        }

        // Generates account status report for all bookings
        public DataTable GetAccountStatusReport()
        {
            string query = @"SELECT 
                g.FirstName + ' ' + g.LastName AS GuestName,
                'PKH-' + CAST(YEAR(b.CheckInDate) AS VARCHAR) + '-' + RIGHT('0000' + CAST(b.BookingID AS VARCHAR), 4) AS BookingRef,
                b.CheckInDate,
                b.TotalAmount,
                ISNULL(b.DepositAmount, 0) AS Deposit,
                b.BookingStatus AS Status
            FROM Bookings b
            INNER JOIN Guests g ON b.GuestID = g.GuestID
            WHERE b.BookingStatus IN ('Pending', 'Confirmed')
            ORDER BY 
                CASE WHEN b.DepositAmount IS NULL THEN 0 ELSE 1 END,
                b.CheckInDate";

            return ExecuteQuery(query);
        }

        // Maps a DataRow to a Booking object with guest and room details
        private Booking MapToBooking(DataRow row)
        {
            Booking booking = new Booking
            {
                BookingID = Convert.ToInt32(row["BookingID"]),
                GuestID = Convert.ToInt32(row["GuestID"]),
                RoomID = Convert.ToInt32(row["RoomID"]),
                CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                AdultsCount = Convert.ToInt32(row["AdultsCount"]),
                ChildrenCount = Convert.ToInt32(row["ChildrenCount"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                DepositAmount = row["DepositAmount"] != DBNull.Value ? Convert.ToDecimal(row["DepositAmount"]) : (decimal?)null,
                BookingStatus = row["BookingStatus"].ToString(),
                SpecialRequirements = row["SpecialRequirements"] != DBNull.Value ? row["SpecialRequirements"].ToString() : null,
                CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                ModifiedDate = row["ModifiedDate"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedDate"]) : (DateTime?)null
            };

            // Map guest information if available in result set
            if (row.Table.Columns.Contains("FirstName"))
            {
                booking.Guest = new Guest
                {
                    GuestID = booking.GuestID,
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : null,
                    IDNumber = row["IDNumber"] != DBNull.Value ? row["IDNumber"].ToString() : null,
                    GuestType = row["GuestType"].ToString()
                };
            }

            // Map room information if available in result set
            if (row.Table.Columns.Contains("RoomNumber"))
            {
                booking.Room = new Room
                {
                    RoomID = booking.RoomID,
                    RoomNumber = row["RoomNumber"].ToString(),
                    RoomType = row["RoomType"].ToString(),
                    HotelID = Convert.ToInt32(row["HotelID"])
                };
            }

            return booking;
        }
    }
}