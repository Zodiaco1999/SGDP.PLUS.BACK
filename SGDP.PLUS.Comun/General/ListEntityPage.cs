namespace SGDP.PLUS.Comun.General;

public class ListEntityPage<TEntity> where TEntity : Entity
{
    public int TotalItems { get; set; }

    public IEnumerable<TEntity> Items { get; set; } = Enumerable.Empty<TEntity>();
}
