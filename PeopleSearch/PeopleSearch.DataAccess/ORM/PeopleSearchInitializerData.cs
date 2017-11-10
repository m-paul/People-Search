using PeopleSearch.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.ORM
{
    /// <summary>
    /// Static class holding methods to gather up seed data
    /// </summary>
    public static class PeopleSearchInitializerData
    {
        /// <summary>
        /// Gets person seed data
        /// </summary>
        /// <returns>List of persons and their related data</returns>
        public static List<Person> GetPersons()
        {
            var result = new List<Person>
            {
                new Person
                {
                    ImageUrl = "Files/face-00.jpg",
                    DateOfBirth = new DateTime(DateTime.Now.Year - 100, DateTime.Now.Month, 1),
                    FirstName = "Matt",
                    LastName = "Paul",
                    AddressLine1 = "18 West Broad Street",
                    City = "Richmond",
                    State = "VA",
                    ZipCode = "23220",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Development" },
                        new PersonInterest { Interest = "Analysis" },
                        new PersonInterest { Interest = "Design" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-01.jpg",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    FirstName = "Anne",
                    LastName = "Arnette",
                    AddressLine1 = "123 6th Street",
                    AddressLine2 = "Apt C",
                    City = "Melborne",
                    State = "FL",
                    ZipCode = "32904",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Acting" },
                        new PersonInterest { Interest = "Script Writing" },
                        new PersonInterest { Interest = "Stand Up" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-02.jpg",
                    DateOfBirth = new DateTime(1970, 2, 2),
                    FirstName = "Belle",
                    LastName = "Brook",
                    AddressLine1 = "71 Pilgrim Avenue",
                    City = "Chevy Chase",
                    State = "MD",
                    ZipCode = "20815",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Baseball" },
                        new PersonInterest { Interest = "Design" },
                        new PersonInterest { Interest = "Illustration" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-03.jpg",
                    DateOfBirth = new DateTime(1975, 3, 3),
                    FirstName = "Clark",
                    LastName = "Carson",
                    AddressLine1 = "70 Bowman Street",
                    City = "South Windsor",
                    State = "CT",
                    ZipCode = "06074",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Coding" },
                        new PersonInterest { Interest = "Dodgeball" },
                        new PersonInterest { Interest = "Ham Radio" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-04.jpg",
                    DateOfBirth = new DateTime(1990, 4, 4),
                    FirstName = "Daniel",
                    LastName = "Douglas",
                    AddressLine1 = "4 Goldfield Road",
                    City = "Honolulu",
                    State = "HI",
                    ZipCode = "96815",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Design" },
                        new PersonInterest { Interest = "UX" },
                        new PersonInterest { Interest = "Basket Weaving" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-05.jpg",
                    DateOfBirth = new DateTime(1995, 5, 5),
                    FirstName = "Elliot",
                    LastName = "Enerson",
                    AddressLine1 = "44 Shirley Avenue",
                    City = "West Chicago",
                    State = "IL",
                    ZipCode = "60185",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Entertainment" },
                        new PersonInterest { Interest = "Pirates" },
                        new PersonInterest { Interest = "Beards" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-06.jpg",
                    DateOfBirth = new DateTime(1990, 6, 6),
                    FirstName = "Fiona",
                    LastName = "Flourence",
                    AddressLine1 = "514 South Magnolia Street",
                    City = "Orlando",
                    State = "FL",
                    ZipCode = "32806",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Fashion" },
                        new PersonInterest { Interest = "Arts" },
                        new PersonInterest { Interest = "Roller Derby" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-07.jpg",
                    DateOfBirth = new DateTime(1985, 7, 7),
                    FirstName = "Ginny",
                    LastName = "Gabel",
                    AddressLine1 = "532 West Street",
                    City = "District Heights",
                    State = "MD",
                    ZipCode = "20747",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Grilling" },
                        new PersonInterest { Interest = "Color Guard" },
                        new PersonInterest { Interest = "Knife Throwing" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-08.jpg",
                    DateOfBirth = new DateTime(1980, 8, 8),
                    FirstName = "Harold",
                    LastName = "Holc",
                    AddressLine1 = "307 Plumb Branch Street",
                    City = "Glastonbury",
                    State = "CT",
                    ZipCode = "06033",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Horseback Riding" },
                        new PersonInterest { Interest = "Running" },
                        new PersonInterest { Interest = "Party Balloon Animals" },
                    }
                },
                new Person
                {
                    ImageUrl = "Files/face-09.jpg",
                    DateOfBirth = new DateTime(1990, 9, 9),
                    FirstName = "Inez",
                    LastName = "Ingred",
                    AddressLine1 = "9465 Courtland Drive",
                    City = "Lorain",
                    State = "OH",
                    ZipCode = "44052",
                    Interests = new List<PersonInterest>
                    {
                        new PersonInterest { Interest = "Insect Collecting" },
                        new PersonInterest { Interest = "Gardening" },
                        new PersonInterest { Interest = "Spelunking" },
                    }
                }
            };

            return result;
        }
    }
}
