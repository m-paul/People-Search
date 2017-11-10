using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.Entities
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int PersonId { get; set; }
        
        /// <summary>
        /// Relative URL to image file in web client
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// First line of address
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Second line of address
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// Zip Code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Interests Navigation Property
        /// </summary>
        public virtual ICollection<PersonInterest> Interests { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Person()
        {
            Interests = new List<PersonInterest>();
        }
    }
}
