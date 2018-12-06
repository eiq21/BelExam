using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        #region SQL Queries
        /// <summary>
        /// Ejecuta un query personalizado
        /// </summary>
        /// <param name="entity"></param>
        IQueryable<T> SelectQuery(string query, params object[] parameters);
        int ExecuteSqlCommand(string query, params object[] parameters);

        /// <summary>
        /// Ejecuta un query personalizado y espera un retorno a cambio
        /// </summary>
        /// <param name="entity"></param>
        IQueryable<I> ExecuteSqlCommand<I>(string query, params object[] parameters) where I : class;
        #endregion

    }
}
