using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Entidades;
using System.Data;
using EFCore.BulkExtensions;

namespace SGDP.PLUS.Comun.UnidadTrabajo;

public class UnitOfWorkBase : DbContext, IUnitOfWorkAsync
{
    private readonly IContextAccessor _contextAccessor;

    public UnitOfWorkBase(DbContextOptions opcionesDBContext, IContextAccessor contextAccessor) : base(opcionesDBContext)
    {
        _contextAccessor = contextAccessor;
    }

    public int? CommandTimeout
    {
        get => base.Database.GetDbConnection().ConnectionTimeout;
        set => base.Database.SetCommandTimeout(value);
    }

    //public virtual int SaveChanges() => _context.SaveChanges();

    public override int SaveChanges()
    {
        SetAudit();

        return base.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        SetAudit();

        return base.SaveChangesAsync();
    }
     
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAudit();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetAudit()
    {
        foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is CamposLog))
        {
            ((CamposLog)item.Entity).CreaUsuario = _contextAccessor.UserName ?? "NA";
            ((CamposLog)item.Entity).CreaFecha = DateTime.Now;
            ((CamposLog)item.Entity).CreaMaquina = _contextAccessor.ClientIP;
            ((CamposLog)item.Entity).ModificaUsuario = _contextAccessor.UserName ?? "NA";
            ((CamposLog)item.Entity).ModificaFecha = DateTime.Now;
            ((CamposLog)item.Entity).ModificaMaquina = _contextAccessor.ClientIP;
        }

        foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is CamposLogSoftDelete))
        {
            ((CamposLogSoftDelete)item.Entity).IsDeleted = false;
        }

        foreach (var item in ChangeTracker.Entries().Where(e => (e.State == EntityState.Modified) && e.Entity is CamposLog))
        {
            ((CamposLog)item.Entity).ModificaUsuario = _contextAccessor.UserName ?? "NA";
            ((CamposLog)item.Entity).ModificaFecha = DateTime.Now;
            ((CamposLog)item.Entity).ModificaMaquina = _contextAccessor.ClientIP;
        }

        foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && e.Entity is CamposLogSoftDelete && !((CamposLogSoftDelete)e.Entity).NotSoftDelete))
        {
            ((CamposLogSoftDelete)item.Entity).IsDeleted = true;
            ((CamposLogSoftDelete)item.Entity).ModificaUsuario = _contextAccessor.UserName ?? "NA";
            ((CamposLogSoftDelete)item.Entity).ModificaFecha = DateTime.Now;
            ((CamposLogSoftDelete)item.Entity).ModificaMaquina = _contextAccessor.ClientIP;
            item.State = EntityState.Unchanged;
        }
    }

    public virtual IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
    {
        if (base.Database.GetDbConnection().State != ConnectionState.Open)
        {
            base.Database.OpenConnection();
        }
        //Transaction = base.Database.BeginTransaction(isolationLevel);
        return base.Database.BeginTransaction(isolationLevel);
    }

    public void ITBulkInsert<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 30) where T : class
    {
        this.BulkInsert(entities, new BulkConfig { BulkCopyTimeout = bulkCopyTimeout }, progress: progress);
    }

    public async Task ITBulkInsertAsync<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 30) where T : class
    {
        await this.BulkInsertAsync(entities, new BulkConfig { BulkCopyTimeout = bulkCopyTimeout }, progress: progress);
    }

    public async Task ITBulkDeleteAsync<T>(IList<T> entities, Action<decimal> progress = null, int bulkCopyTimeout = 30) where T : class
    {
        await this.BulkDeleteAsync(entities, new BulkConfig { BulkCopyTimeout = bulkCopyTimeout }, progress: progress);
    }
}
