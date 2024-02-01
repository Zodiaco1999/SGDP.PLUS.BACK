using SGDP.PLUS.Comun.General;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SGDP.PLUS.Comun.Repositorios
{
    public sealed class QueryFluent<TEntity> : IQueryFluent<TEntity> where TEntity : Entity
    {
        private readonly Expression<Func<TEntity, bool>> _expression;
        private readonly List<Expression<Func<TEntity, object>>> _includes;
        private readonly List<string> _includesString;
        private readonly Repository<TEntity> _repository;
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> _orderBy;
        private string _propertyOrderBy;
        private string _sortDirection; //asc, desc
        private bool _ignoreQueryFilters = false;

        public QueryFluent(Repository<TEntity> repository)
        {
            _repository = repository;
            _includes = new List<Expression<Func<TEntity, object>>>();
            _includesString = new List<string>();
        }

        public QueryFluent(Repository<TEntity> repository, IQueryObject<TEntity> queryObject) : this(repository)
        {
            _expression = queryObject.Query();
        }

        public QueryFluent(Repository<TEntity> repository, Expression<Func<TEntity, bool>> expression) : this(repository)
        {
            _expression = expression;
        }

        public QueryFluent(Repository<TEntity> repository, Expression<Func<TEntity, bool>> expression, bool ignoreQueryFilters) : this(repository)
        {
            _expression = expression; _ignoreQueryFilters = ignoreQueryFilters;
        }

        public QueryFluent(Repository<TEntity> repository, bool ignoreQueryFilters) : this(repository)
        {
            _ignoreQueryFilters = ignoreQueryFilters;
        }

        public IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression)
        {
            _includes.Add(expression);
            return this;
        }

        public IQueryFluent<TEntity> Include(string include)
        {
            _includesString.Add(include);
            return this;
        }

        public IEnumerable<TEntity> SelectPage(int page, int pageSize, out int totalCount)
        {
            totalCount = _repository.Select(_expression).Count();
            return _repository.Select(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString, _ignoreQueryFilters, page, pageSize);
        }

        public IEnumerable<TEntity> Select()
        {
            return _repository.Select(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.Select(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString, _ignoreQueryFilters).Select(selector);
        }

        public async Task<IEnumerable<TEntity>> SelectAsync()
        {
            return await _repository.SelectAsync(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString, _ignoreQueryFilters);
        }

        public async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return await Task.FromResult(_repository.Select(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString, _ignoreQueryFilters).Select(selector));
        }

        public IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _repository.SelectQuery(query, parameters).AsQueryable();
        }

        public IQueryFluent<TEntity> OrderBy(string orderBy, bool orderAsc = true)
        {
            _propertyOrderBy = orderBy;
            _sortDirection = orderAsc == true ? "asc" : "desc";
            return this;
        }

        public async Task<ListEntityPage<TEntity>> SelectPageAsync(int page, int pageSize)
        {
            ListEntityPage<TEntity> result = new ListEntityPage<TEntity>()
            {
                TotalItems = await _repository.CountAsync(_expression, _includes, _includesString),
                Items = await _repository.SelectAsync(_expression, _orderBy, _propertyOrderBy, _sortDirection, _includes, _includesString, _ignoreQueryFilters, page, pageSize)
            };

            return result;
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await _repository.FirtsOrDefaultAsync(_expression, _includes, _includesString, _ignoreQueryFilters);
        }
        public TEntity FirstOrDefault()
        {
            return _repository.FirtsOrDefault(_expression, _includes, _includesString, _ignoreQueryFilters).FirstOrDefault();
        }
    }
}
