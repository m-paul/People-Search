using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Web.Common;

namespace PeopleSearch.Web.Test
{
    [TestClass]
    public class DateHelperTest
    {
        [TestMethod]
        public void NotPastInCurrentYearDayTest_Test()
        {
            // Set up test
            var birthDate = new DateTime(2016, 6, 30);
            var currentDate = new DateTime(2018, 5, 15);

            // Execute Test
            var result = DateHelper.AgeInYears(birthDate, currentDate);

            // Verify
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void NotPastInCurrentYear_Test()
        {
            // Set up test
            var birthDate = new DateTime(2016, 6, 1);
            var currentDate = new DateTime(2017, 5, 1);

            // Execute Test
            var result = DateHelper.AgeInYears(birthDate, currentDate);

            // Verify
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PastInCurrentYear_Test()
        {
            // Set up test
            var birthDate = new DateTime(2016, 6, 1);
            var currentDate = new DateTime(2017, 7, 1);

            // Execute Test
            var result = DateHelper.AgeInYears(birthDate, currentDate);

            // Verify
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void NotPastLeapYear_Test()
        {
            // Set up test
            var birthDate = new DateTime(2016, 2, 29);
            var currentDate = new DateTime(2024, 2, 1);

            // Execute Test
            var result = DateHelper.AgeInYears(birthDate, currentDate);

            // Verify
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void PastLeapYear_Test()
        {
            // Set up test
            var birthDate = new DateTime(2016, 2, 29);
            var currentDate = new DateTime(2024, 3, 1);

            // Execute Test
            var result = DateHelper.AgeInYears(birthDate, currentDate);

            // Verify
            Assert.AreEqual(8, result);
        }
    }
}
