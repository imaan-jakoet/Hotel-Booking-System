using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaKamnandi.BusinessLayer
{
    // Defines seasons for pricing strategy
    public enum Season
    {
        Low,   // Off-peak season with standard rates
        Mid,   // Moderate season with slight rate increase
        High   // Peak season with highest rates
    }

    // Handles seasonal pricing calculations for hotel rooms
    public class SeasonalRate
    {
        // Determines the season based on month of the year
        public static Season GetSeason(DateTime date)
        {
            int month = date.Month;

            // High season: December, January, April (school holidays)
            if (month == 12 || month == 1 || month == 4)
                return Season.High;

            // Mid season: June, July (winter holidays), March, October
            if (month == 6 || month == 7 || month == 3 || month == 10)
                return Season.Mid;

            // Low season: all other months
            return Season.Low;
        }

        // Returns the rate multiplier for a given season
        public static decimal GetRateMultiplier(Season season)
        {
            switch (season)
            {
                case Season.High:
                    return 1.5m; // 50% increase during peak season
                case Season.Mid:
                    return 1.2m; // 20% increase during moderate season
                case Season.Low:
                    return 1.0m; // Standard rate during off-peak
                default:
                    return 1.0m; // Fallback to standard rate
            }
        }

        // Calculates the final rate including seasonal adjustments
        public static decimal CalculateRate(decimal baseRate, DateTime date)
        {
            Season season = GetSeason(date);
            return baseRate * GetRateMultiplier(season);
        }
    }
}