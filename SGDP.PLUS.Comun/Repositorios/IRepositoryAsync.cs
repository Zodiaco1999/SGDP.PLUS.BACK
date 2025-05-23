﻿using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.Comun.Repositorios
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(params object[] keyValues);

        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);

        Task<bool> DeleteAsync(params object[] keyValues);

        //Task<bool> InsertAsync(TEntity builder);

        //Task<bool> UpdateAsync(TEntity builder);

        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);

        Task<IEnumerable<TEntity>> SelectQueryAsync(string query, params object[] parameters);

        Task<IEnumerable<TEntity>> SelectQueryAsync(string query, CancellationToken cancellationToken, params object[] parameters);
    }
}
