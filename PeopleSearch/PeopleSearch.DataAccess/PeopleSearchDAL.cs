using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess
{
    /// <summary>
    /// Describes a data access component for the People Search Application
    /// </summary>
    public interface IPeopleSearchDAL : IRepository
    {
    }

    /// <summary>
    /// Data Access component for the People Search Application
    /// </summary>
    /// <remarks>
    /// Use to added stored procedures and functions or wrap additional functionality, like auditing.
    /// Outside of this library, use this class instead of the context directly as a means of abstraction.
    /// </remarks>
    public class PeopleSearchDAL : Repository<ORM.PeopleSearchContext>, IPeopleSearchDAL
    {
    }
}
