using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.DataAccess
{
    /// <summary>
    /// Data Repository
    /// </summary>
    /// <remarks>
    /// Design based on a combination of https://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
    /// and http://cpratt.co/truly-generic-repository/
    /// </remarks>
    public interface IRepository
    {
        /// <summary>
        /// Returns all elements
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>Sequence of entities</returns>
        List<TEntity> GetList<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns a sequence matching criteria
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="filter">Criteria to limit results to</param>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>Sequence of entities</returns>
        List<TEntity> GetList<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns a sequence matching criteria
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>Sequence of entities</returns>
        List<TEntity> GetList<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns a sequence matching criteria
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>Sequence of entities</returns>
        List<TResult> GetList<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns a sequence matching criteria
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="queryProvider">Function providing the query to base results on</param>
        /// <returns>Sequence of entities</returns>
        List<TResult> GetList<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider);

        /// <summary>
        /// Returns the only element of a sequence matching criteria, or a default value if the sequence is empty;
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>Single entity matching criteria if found, otherwise null</returns>
        TEntity GetOne<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns the only element of a sequence matching criteria, or a default value if the sequence is empty;
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="filter">Criteria to limit results to</param>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>Single entity matching criteria if found, otherwise null</returns>
        TEntity GetOne<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns the only element of a sequence matching criteria, or a default value if the sequence is empty;
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>Single entity matching criteria if found, otherwise null</returns>
        TEntity GetOne<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns the only element of a sequence matching criteria, or a default value if the sequence is empty;
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>Single entity matching criteria if found, otherwise null</returns>
        TResult GetOne<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns the only element of a sequence matching criteria, or a default value if the sequence is empty;
        /// This method throws an exception if there is more than one element in the sequence.
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="queryProvider">Function providing the query to base results on</param>
        /// <returns>Single entity matching criteria if found, otherwise null</returns>
        TResult GetOne<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider);

        /// <summary>
        /// Returns the first element of a sequence matching criteria, or a default value if the sequence is empty
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>First entity matching criteria if found, otherwise null</returns>
        TEntity GetFirst<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns the first element of a sequence matching criteria, or a default value if the sequence is empty
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="filter">Criteria to limit results to</param>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns>First entity matching criteria if found, otherwise null</returns>
        TEntity GetFirst<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class;

        /// <summary>
        /// Returns the first element of a sequence matching criteria, or a default value if the sequence is empty
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>First entity matching criteria if found, otherwise null</returns>
        TEntity GetFirst<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns the first element of a sequence matching criteria, or a default value if the sequence is empty
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="transformBy">Tranformation function</param>
        /// <returns>First entity matching criteria if found, otherwise null</returns>
        TResult GetFirst<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class;

        /// <summary>
        /// Returns the first element of a sequence matching criteria, or a default value if the sequence is empty
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="queryProvider">Function providing the query to base results on</param>
        /// <returns>First entity matching criteria if found, otherwise null</returns>
        TResult GetFirst<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider);

        /// <summary>
        /// Returns element matched by primary key values
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        /// <returns>The entity found, or null.</returns>
        TEntity GetById<TEntity>(params object[] keyValues)
        where TEntity : class;

        /// <summary>
        /// Gets number of elements matching criteria
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="filter">Criteria to limit results to</param>
        /// <returns>Count of matching elements</returns>
        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

        /// <summary>
        /// Returns true if an element matching criteria can be found
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="filter">Criteria to limit results to</param>
        /// <returns>True if element can be found; otherwise false</returns>
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class;

        /// <summary>
        /// Persists a new entity to the database
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="item">Item to persist</param>
        void AddEntity<TEntity>(TEntity item)
        where TEntity : class;

        /// <summary>
        /// Persists updates to existing entities to the database
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="item">Item to persist</param>
        void UpdateEntity<TEntity>(TEntity item)
        where TEntity : class;

        /// <summary>
        /// Deletes entities from the database
        /// </summary>
        /// <typeparam name="TEntity">POCO class</typeparam>
        /// <param name="item">Item to delete</param>
        void DeleteEntity<TEntity>(TEntity item)
        where TEntity : class;

        /// <summary>
        /// Persists changes to entities and items also existing in the graph
        /// </summary>
        /// <param name="items">Items to persist</param>
        void UpdateGraph(params IGraphEntity[] items);
    }
}
