using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace SEG.Comun.UnidadTrabajo;

public interface IUnitOfWork
{
    int SaveChanges();

    //int ExecuteSqlCommand(string sql, params object[] parameters);

    IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);

    //bool Commit();

    //void Rollback();

    EntityEntry<TEntity> Entry<TEntity>(TEntity builder) where TEntity : class;

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    void ITBulkInsert<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 30) where T : class;
}
