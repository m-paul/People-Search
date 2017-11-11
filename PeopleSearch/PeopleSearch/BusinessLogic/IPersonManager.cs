using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.BusinessLogic
{
    public interface IPersonManager
    {
        /// <summary>
        /// Search for a people matching criteria
        /// </summary>
        /// <param name="criteria">Search Criteria</param>
        /// <returns>List of mathing person dtos</returns>
        List<PersonDto> Search(PersonSearchCriteriaDto criteria);
    }
}