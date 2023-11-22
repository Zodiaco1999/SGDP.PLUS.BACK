using SGDP.PLUS.Comun.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SGDP.PLUS.Comun.Repositorios
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Find(params object[] keyValues);

        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        void Insert(TEntity builder);

        void InsertRange(IEnumerable<TEntity> entities);

        void Update(TEntity builder, bool traverseGraph = true);

        void Delete(params object[] keyValues);

        void Delete(TEntity builder);

        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);

        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);

        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query, bool ignoreQueryFilters);

        IQueryFluent<TEntity> Query(bool ignoreQueryFilters);

        IQueryFluent<TEntity> Query();

        IQueryable<TEntity> Queryable();
    }
}
