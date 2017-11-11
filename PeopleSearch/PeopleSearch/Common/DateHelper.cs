using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Common
{
    public static class DateHelper
    {
        /// <summary>
        /// Get age in years for a given birth date as of today
        /// </summary>
        /// <param name="birthDate">Date of Birth</param>
        /// <returns>Age in Years</returns>
        public static int AgeInYears(DateTime birthDate)
        {
            return AgeInYears(birthDate, DateTime.Today);
        }

        /// <summary>
        /// Get age in years for a given birth date
        /// </summary>
        /// <param name="birthDate">Date of Birth</param>
        /// <param name="asOfDate">As of Date</param>
        /// <returns>Age in Years</returns>
        public static int AgeInYears(DateTime birthDate, DateTime asOfDate)
        {
            var days = asOfDate.Day - birthDate.Day;
            var months = asOfDate.Month - birthDate.Month;
            var years = asOfDate.Year - birthDate.Year;
            if (days < 0) months--;
            return (months >= 0) ? years : years - 1;
        }
    }
}