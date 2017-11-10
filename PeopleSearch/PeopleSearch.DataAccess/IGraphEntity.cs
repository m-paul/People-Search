using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess
{
    /// <summary>
    /// Describes the state of an entity within a graph
    /// </summary>
    public enum EntityGraphState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

    /// <summary>
    /// Describes an entity as part of a larger graph
    /// </summary>
    public interface IGraphEntity
    {
        /// <summary>
        /// State of the entity within the graph
        /// Unchanged is default value
        /// </summary>
        EntityGraphState EntityState { get; set; }
    }
}
