using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer
{
    // Calculates room rates based on seasonal pricing and guest composition
    public class RateCalculator
    {
        // Base rates per person for each season
        private const decimal LOW_SEASON_RATE = 550m;   // Off-peak season rate
        private const decimal MID_SEASON_RATE = 750m;   // Moderate season rate
        private const decimal HIGH_SEASON_RATE = 995m;  // Peak season rate

        // Determines the season based on month of the year
        public static string GetSeason(DateTime date)
        {
            int month = date.Month;

            // High Season: December-January, April, June-July (peak periods)
            if (month == 12 || month == 1 || month == 4 || month == 6 || month == 7)
                return "High";

            // Mid Season: March, May, August-September (shoulder periods)
            if (month == 3 || month == 5 || month == 8 || month == 9)
                return "Mid";

            // Low Season: February, October-November (off-peak periods)
            return "Low";
        }

        // Returns the seasonal rate for a specific date
        public static decimal GetSeasonalRate(DateTime date)
        {
            string season = GetSeason(date);

            switch (season)
            {
                case "High":
                    return HIGH_SEASON_RATE;
                case "Mid":
                    return MID_SEASON_RATE;
                case "Low":
                    return LOW_SEASON_RATE;
                default:
                    return MID_SEASON_RATE;  // Fallback to mid season rate
            }
        }

        // Calculates total booking cost including seasonal rates and guest composition
        public static decimal CalculateBookingTotal(DateTime checkIn, DateTime checkOut, int adults, int children)
        {
            decimal total = 0;
            int nights = (checkOut - checkIn).Days;

            // Calculate cost for each night individually
            for (int i = 0; i < nights; i++)
            {
                DateTime currentDate = checkIn.AddDays(i);
                decimal ratePerNight = GetSeasonalRate(currentDate);

                // Adult charges at full rate
                decimal adultCharge = adults * ratePerNight;

                // Children charges at half rate (ages 5-16)
                decimal childCharge = children * (ratePerNight * 0.5m);

                total += adultCharge + childCharge;
            }

            return total;
        }

        // Calculates required deposit amount (10% of total)
        public static decimal CalculateDeposit(decimal totalAmount)
        {
            return Math.Round(totalAmount * 0.10m, 2);
        }

        // Calculates average nightly rate across the booking period
        public static decimal GetAverageRate(DateTime checkIn, DateTime checkOut)
        {
            decimal totalRate = 0;
            int nights = (checkOut - checkIn).Days;

            // Sum rates for all nights in the booking
            for (int i = 0; i < nights; i++)
            {
                DateTime currentDate = checkIn.AddDays(i);
                totalRate += GetSeasonalRate(currentDate);
            }

            return nights > 0 ? Math.Round(totalRate / nights, 2) : 0;
        }
    }
}