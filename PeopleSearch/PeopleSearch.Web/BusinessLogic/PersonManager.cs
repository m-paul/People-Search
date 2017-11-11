using PeopleSearch.DataAccess;
using PeopleSearch.DataAccess.Entities;
using PeopleSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Web.BusinessLogic
{ 
    public class PersonManager : IPersonManager
    {
        private readonly IPeopleSearchDAL _dal;

        public PersonManager(IPeopleSearchDAL dal)
        {
            _dal = dal;
        }

        public List<PersonDto> Search(PersonSearchCriteriaDto criteria)
        {
            // Init criteria if not specified
            if (criteria == null) criteria = new PersonSearchCriteriaDto();

            // Clean up criteria name
            criteria.Name = criteria?.Name?.Trim() ?? "";
            if (criteria.Name.Length == 0) criteria.Name = null;

            // Execute search
            var result = _dal.GetList<Person, PersonDto>(t =>
                    from p in t
                    where (criteria.Name == null || (p.FirstName.Contains(criteria.Name) || p.LastName.Contains(criteria.Name)))
                    select new PersonDto
                    {
                        PersonId = p.PersonId,
                        ImageUrl = p.ImageUrl,
                        DateOfBirth = p.DateOfBirth,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        AddressLine1 = p.AddressLine1,
                        AddressLine2 = p.AddressLine2,
                        City = p.City,
                        State = p.State,
                        ZipCode = p.ZipCode,
                        Interests = p.Interests.Select(j => j.Interest).ToList()
                    }
                );

            // Return results
            return result;
        }
    }
}