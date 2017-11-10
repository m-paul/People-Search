using PeopleSearch.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess.ORM
{
    /// <summary>
    /// Entity Framework Data Context.
    /// </summary>
    /// <remarks>
    /// Avoid using directly outside of this library. Instead use the PeopleSearchDAL
    /// </remarks>
    public class PeopleSearchContext : DbContext, ISetProvider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PeopleSearchContext()
        {
            Database.SetInitializer<PeopleSearchContext>(new PeopleSearchInitializer());
        }

        /// <summary>
        /// Returns an IQueryable instance for access to entities of the given type
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to return</typeparam>
        /// <returns>Set for the entity type</returns>
        /// <remarks>Used by the PeopleSearchDAL to support complex queries</remarks>
        IQueryable<TEntity> ISetProvider.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        /// <summary>
        /// Collection of people
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        
        /// <summary>
        /// Collection of person interests
        /// </summary>
        public DbSet<PersonInterest> PersonInterests { get; set; }

        /// <summary>
        /// Specifies additional constraints and defines relationships and metadata that should be applied to the model
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Don't pluralize
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure Person
            modelBuilder.Entity<Person>().HasKey(t => t.PersonId);
            modelBuilder.Entity<Person>().Property(i => i.ImageUrl).HasMaxLength(255);
            modelBuilder.Entity<Person>().Property(i => i.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.LastName).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.AddressLine1).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.City).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.State).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(i => i.ZipCode).HasMaxLength(5);

            // Configure PersonInterest
            modelBuilder.Entity<PersonInterest>().HasKey(t => t.PersonInterestId);
            modelBuilder.Entity<PersonInterest>().Property(i => i.Interest).HasMaxLength(100);
        }
    }
}
