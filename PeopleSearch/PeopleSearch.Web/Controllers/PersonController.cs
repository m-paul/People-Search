using PeopleSearch.Web.BusinessLogic;
using PeopleSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeopleSearch.Web.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpPost]
        [Route("api/person/search")]
        public IHttpActionResult Search(PersonSearchCriteriaDto criteria)
        {
            // Simulated wait
            if (criteria != null) System.Threading.Thread.Sleep(2000);
            
            // Execute search
            var result = _personManager.Search(criteria);

            // Return results
            return Ok(result);
        }
    }
}
