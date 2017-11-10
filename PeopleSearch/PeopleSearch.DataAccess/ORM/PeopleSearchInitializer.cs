using PeopleSearch.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.ORM
{
    /// <summary>
    /// Responsible for providing seed data to the database
    /// </summary>
    public class PeopleSearchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleSearchContext>
    {
        /// <summary>
        /// Method adds data to the context for seeding
        /// </summary>
        /// <param name="context">Context to seed</param>
        protected override void Seed(PeopleSearchContext context)
        {
            var persons = PeopleSearchInitializerData.GetPersons();
            context.Persons.AddRange(persons);
            context.SaveChanges();
        }

    }
}
