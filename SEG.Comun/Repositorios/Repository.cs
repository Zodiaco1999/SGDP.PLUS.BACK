using Microsoft.EntityFrameworkCore;
using SEG.Comun.General;
using SEG.Comun.UnidadTrabajo;
using System.Linq.Expressions;


namespace SEG.Comun.Repositorios;

public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
{
    protected readonly DbSet<TEntity> Set;
    protected readonly IUnitOfWorkAsync _unitOfWork;

    public Repository(IUnitOfWorkAsync unitOfWork)
    {
        _unitOfWork = unitOfWork;
        Set = _unitOfWork.Set<TEntity>();
    }

    public virtual TEntity Find(params object[] keyValues)
    {
        return Set.Find(keyValues);
    }

    public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
    {
        return Set.FromSqlRaw(query, parameters).AsQueryable();
    }

    public virtual void Insert(TEntity builder)
    {
        Set.Add(builder);
    }
    public virtual void InsertRange(IEnumerable<TEntity> entities)
    {
        Set.AddRange(entities);
    }

    public virtual void Update(TEntity builder, bool traverseGraph = true)
    {
        _unitOfWork.Entry(builder).State = EntityState.Modified;
    }

    public void Delete(params object[] keyValues)
    {
        var builder = Set.Find(keyValues);
        Delete(builder);
    }
    public virtual void Delete(TEntity builder)
    {
        Set.Remove(builder);
    }
    public virtual void Delete(object id)
    {
        var builder = Set.Find(id);
        Delete(builder);
    }
    public IQueryFluent<TEntity> Query() => new QueryFluent<TEntity>(this);

    public virtual IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject) => new QueryFluent<TEntity>(this, queryObject);

    public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query) => new QueryFluent<TEntity>(this, query);

    public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query, bool ignoreQueryFilters) => new QueryFluent<TEntity>(this, query, ignoreQueryFilters);

    public virtual IQueryFluent<TEntity> Query(bool ignoreQueryFilters) => new QueryFluent<TEntity>(this, ignoreQueryFilters);

    public IQueryable<TEntity> Queryable() => Set;

    //public IRepository<T> GetRepository<T>() where T : class, ITrackable => UnitOfWork.Repository<T>();

    public virtual async Task<TEntity> FindAsync(params object[] keyValues) => await Set.FindAsync(keyValues);

    public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => await Set.FindAsync(keyValues, cancellationToken);

    public virtual async Task<bool> DeleteAsync(params object[] keyValues)
    {
        if (await DeleteAsync(CancellationToken.None, keyValues)) return true;
        return false;
    }

    public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    {
        var builder = await FindAsync(cancellationToken, keyValues);

        if (builder == null)
        {
            return false;
        }

        Delete(builder);

        return true;
    }

    internal IQueryable<TEntity> FirtsOrDefault(
       Expression<Func<TEntity, bool>> filter = null,
       List<Expression<Func<TEntity, object>>> includes = null,
       List<string> includesString = null,
       bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = Set;

        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters();
        }

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (includesString != null)
        {
            query = includesString.Aggregate(query, (current, include) => current.Include(include));
        }
        if (filter != null)
        {
            query = query.AsQueryable().Where(filter);
        }
        return query;
    }

    internal IQueryable<TEntity> Select(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string propertyOrderBy = "",
        string sortDirection = "asc",
        List<Expression<Func<TEntity, object>>> includes = null,
        List<string> includesString = null,
        bool ignoreQueryFilters = false,
        int? page = null,
        int? pageSize = null)
    {
        IQueryable<TEntity> query = Set;

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (includesString != null)
        {
            query = includesString.Aggregate(query, (current, include) => current.Include(include));
        }

        if (ignoreQueryFilters)
        {
            query = query.IgnoreQueryFilters();
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }
        else if (!string.IsNullOrWhiteSpace(propertyOrderBy))
        {
            if (sortDirection == "asc")
            {
                query = query.OrderBy(propertyOrderBy);
            }
            else if (sortDirection == "desc")
            {
                query = query.OrderByDescending(propertyOrderBy);
            }
        }

        if (filter != null)
        {
            //query = query.AsExpandable().Where(filter);
            query = query.Where(filter);
        }
        if (page != null && pageSize != null)
        {
            query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
        }
        return query;
    }

    public virtual async Task<IEnumerable<TEntity>> SelectQueryAsync(string query, params object[] parameters)
    {
        return await Set.FromSqlRaw(query, parameters).ToArrayAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> SelectQueryAsync(string query, CancellationToken cancellationToken, params object[] parameters)
    {
        return await Set.FromSqlRaw(query, parameters).ToArrayAsync(cancellationToken);
    }

    internal async Task<IEnumerable<TEntity>> SelectAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string propertyOrderBy = "",
        string sortDirection = "asc",
        List<Expression<Func<TEntity, object>>> includes = null,
        List<string> includesString = null,
        bool ignoreQueryFilters = false,
        int? page = null,
        int? pageSize = null)
    {
        return await Task.FromResult(Select(filter, orderBy, propertyOrderBy, sortDirection, includes, includesString, ignoreQueryFilters, page, pageSize).ToList());
        //return await Select(filter, orderBy, propertyOrderBy, sortDirection, includes, page, pageSize).ToListAsync();
    }

    internal async Task<TEntity> FirtsOrDefaultAsync(
       Expression<Func<TEntity, bool>> filter = null,
       List<Expression<Func<TEntity, object>>> includes = null,
       List<string> includesString = null,
       bool ignoreQueryFilters = false)
    {
        return await Task.FromResult(FirtsOrDefault(filter, includes, includesString, ignoreQueryFilters).FirstOrDefault());
    }

    internal async Task<int> CountAsync(
        Expression<Func<TEntity, bool>> filter = null,
        List<Expression<Func<TEntity, object>>> includes = null,
        List<string> includesString = null
        )
    {
        return await Task.FromResult(Select(filter, includes: includes, includesString: includesString).Count());
        //return await Select(filter).CountAsync();
    }
}