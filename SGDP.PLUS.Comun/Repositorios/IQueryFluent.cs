using SGDP.PLUS.Comun.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGDP.PLUS.Comun.Repositorios
{
    public interface IQueryFluent<TEntity> where TEntity : Entity
    {
        IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        IQueryFluent<TEntity> OrderBy(string orderBy, bool orderAsc = true);

        IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression);

        IQueryFluent<TEntity> Include(string include);

        IEnumerable<TEntity> SelectPage(int page, int pageSize, out int totalCount);

        Task<ListEntityPage<TEntity>> SelectPageAsync(int page, int pageSize);

        IEnumerable<TEntity> Select();

        IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector = null);

        Task<IEnumerable<TEntity>> SelectAsync();

        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector = null);

        Task<TEntity> FirstOrDefaultAsync();

        TEntity FirstOrDefault();

        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);

    }
}
