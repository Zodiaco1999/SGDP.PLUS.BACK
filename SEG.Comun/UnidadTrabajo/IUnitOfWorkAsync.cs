namespace SGDP.PLUS.Comun.UnidadTrabajo;

public interface IUnitOfWorkAsync : IUnitOfWork
{
    Task<int> SaveChangesAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    //Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

    //Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);

    Task ITBulkInsertAsync<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 300) where T : class;

    Task ITBulkDeleteAsync<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 300) where T : class;
}
