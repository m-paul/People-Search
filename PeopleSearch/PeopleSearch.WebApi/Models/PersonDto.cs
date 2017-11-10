using PeopleSearch.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PeopleSearch.WebApi.Models
{
    [DataContract]
    [Serializable]
    public class PersonDto
    {
        [DataMember]
        public int PersonId { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        [DataMember]
        public int? Age
        {
            get
            {
                return DateOfBirth.HasValue 
                    ? DateHelper.AgeInYears(DateOfBirth.Value)
                    : (int?) null;
            }
        }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public List<string> Interests { get; set; }
    }
}