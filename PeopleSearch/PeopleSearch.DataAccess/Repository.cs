using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq.Expressions;
using EntityState = System.Data.Entity.EntityState;

namespace PeopleSearch.DataAccess
{
    public class Repository<T> : IRepository where T : DbContext, ISetProvider, new()
    {

        #region IRepository Members

        public List<TEntity> GetList<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetList(setProvider => GetQueryable(setProvider, null, navigationProperties));
        }

        public List<TEntity> GetList<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetList(setProvider => GetQueryable(setProvider, filter, navigationProperties));
        }

        public List<TEntity> GetList<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class
        {
            return GetList(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public List<TResult> GetList<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class
        {
            return GetList(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public List<TResult> GetList<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider)
        {
            using (var context = new T())
            {
                var query = queryProvider(context);
                return query.ToList();
            }
        }

        public TEntity GetOne<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetOne(setProvider => GetQueryable(setProvider, null, navigationProperties));
        }

        public TEntity GetOne<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetOne(setProvider => GetQueryable(setProvider, filter, navigationProperties));
        }

        public TEntity GetOne<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class
        {
            return GetOne(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public TResult GetOne<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class
        {
            return GetOne(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public TResult GetOne<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider)
        {
            using (var context = new T())
            {
                var query = queryProvider(context);
                return query.SingleOrDefault();
            }
        }

        public TEntity GetFirst<TEntity>(params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetFirst(setProvider => GetQueryable(setProvider, null, navigationProperties));
        }

        public TEntity GetFirst<TEntity>(
        Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] navigationProperties)
        where TEntity : class
        {
            return GetFirst(setProvider => GetQueryable(setProvider, filter, navigationProperties));
        }

        public TEntity GetFirst<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> transformBy)
        where TEntity : class
        {
            return GetFirst(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public TResult GetFirst<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class
        {
            return GetFirst(setProvider => transformBy(setProvider.Set<TEntity>()));
        }

        public TResult GetFirst<TResult>(Func<ISetProvider, IQueryable<TResult>> queryProvider)
        {
            using (var context = new T())
            {
                var query = queryProvider(context);
                return query.FirstOrDefault();
            }
        }

        public TEntity GetById<TEntity>(params object[] keyValues)
        where TEntity : class
        {
            using (var context = new T())
            {
                return context.Set<TEntity>().Find(keyValues);
            }
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
        {
            using (var context = new T())
            {
                return GetQueryable(context, filter).Count();
            }
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : class
        {
            using (var context = new T())
            {
                return GetQueryable(context, filter).Any();
            }
        }

        public void AddEntity<TEntity>(TEntity item)
        where TEntity : class
        {
            using (var context = new T())
            {
                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateEntity<TEntity>(TEntity item)
        where TEntity : class
        {
            using (var context = new T())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteEntity<TEntity>(TEntity item)
        where TEntity : class
        {
            using (var context = new T())
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateGraph(params IGraphEntity[] items)
        {
            var trackedEntities = new List<IGraphEntity>();

            using (var context = new T())
            {
                // Add all items to context
                foreach (var item in items)
                {
                    var dbSet = context.Set(item.GetType());
                    dbSet.Add(item);
                }

                // Set the state of tracked items
                foreach (var entry in context.ChangeTracker.Entries<IGraphEntity>())
                {
                    var entity = entry.Entity;
                    entry.State = GetEntityState(entity.EntityState);
                    trackedEntities.Add(entity);
                }

                // Save cumulative changes
                context.SaveChanges();
            }

            // The database now reflects the added or updated entities, so their entity states
            // are no longer valid. Reset the entity state of modified entities.
            foreach (var entity in trackedEntities.Where(
            e => e.EntityState == EntityGraphState.Added || e.EntityState == EntityGraphState.Modified))
            {
                entity.EntityState = EntityGraphState.Unchanged;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts an EntityGraphState enumeration to an EntityState enumeration
        /// </summary>
        /// <param name="entityState">State enumeration to convert</param>
        /// <returns>Entity State enumeration</returns>
        protected static EntityState GetEntityState(EntityGraphState entityState)
        {
            switch (entityState)
            {
                case EntityGraphState.Unchanged:
                    return EntityState.Unchanged;
                case EntityGraphState.Added:
                    return EntityState.Added;
                case EntityGraphState.Modified:
                    return EntityState.Modified;
                case EntityGraphState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Detached;
            }
        }

        /// <summary>
        /// Gets a queryable object
        /// </summary>
        /// <typeparam name="TEntity">POCO entity</typeparam>
        /// <param name="context">DBContext to pull data from</param>
        /// <param name="filter">Expression to filter data by</param>
        /// <param name="navigationProperties">Navigation properties to include</param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
        ISetProvider context,
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, object>>[] navigationProperties = null)
        where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (navigationProperties != null)
            {
                query =
                navigationProperties
                .Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            }

            return query;
        }

        /// <summary>
        /// Gets a queryable object
        /// </summary>
        /// <typeparam name="TEntity">POCO entity</typeparam>
        /// <typeparam name="TResult">Result shape</typeparam>
        /// <param name="context">DBContext to pull data from</param>
        /// <param name="transformBy">Function to transform result by</param>
        /// <returns></returns>
        protected virtual IQueryable<TResult> GetQueryableAs<TEntity, TResult>(
        DbContext context,
        Func<IQueryable<TEntity>, IQueryable<TResult>> transformBy)
        where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            var newQuery = transformBy(query);
            return newQuery;
        }

        #endregion

    }
}
