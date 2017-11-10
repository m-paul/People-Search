using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.Entities
{
    /// <summary>
    /// Describes a person's interest
    /// </summary>
    public class PersonInterest : BaseEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int PersonInterestId { get; set; }

        /// <summary>
        /// Person Id Foreign Key
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Description of Interest
        /// </summary>
        public string Interest { get; set; }

        /// <summary>
        /// Person Navigation Property
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
