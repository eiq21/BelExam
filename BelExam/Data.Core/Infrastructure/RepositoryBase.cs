using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class,new()
    {
        #region Properties
        private DIContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DIContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        private IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties,
                                                      IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }

        public T First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        #endregion

        #region SQL Queries
        /// <summary>
        /// Ejecuta un query personalizado
        /// </summary>
        /// <param name="entity"></param>
        public virtual IQueryable<T> SelectQuery(string query, params object[] parameters) {
            return DbContext.Set<T>().SqlQuery(query, parameters).AsQueryable();
        }
        public virtual int ExecuteSqlCommand(string query, params object[] parameters) {
            return DbContext.Database.ExecuteSqlCommand(query, parameters);
        }

        /// <summary>
        /// Ejecuta un query personalizado y espera un retorno a cambio
        /// </summary>
        /// <param name="entity"></param>
        public IQueryable<I> ExecuteSqlCommand<I>(string query, params object[] parameters) where I : class {
            return DbContext.Database.SqlQuery<I>(query, parameters).AsQueryable();
        }
        #endregion
    }
}
