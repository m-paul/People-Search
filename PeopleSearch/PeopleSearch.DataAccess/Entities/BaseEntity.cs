using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.Entities
{
    /// <summary>
    /// Entity capable of being described as part of a larger graph
    /// </summary>
    public abstract class BaseEntity : IGraphEntity
    {
        [NotMapped]
        public EntityGraphState EntityState { get; set; }
    }
}
