using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess
{
    /// <summary>
    /// Entity Set Provider
    /// </summary>
    public interface ISetProvider
    {
        /// <summary>
        /// Returns an IQueryable instance for access to entities of the given type
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to return</typeparam>
        /// <returns>Set for the entity type</returns>
        IQueryable<TEntity> Set<TEntity>() where TEntity : class;
    }
}
