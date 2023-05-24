using System.Collections.Generic;

namespace SEG.Comun.General
{
    public class ListEntityPage<TEntity> where TEntity : Entity
    {
        public int TotalItems { get; set; }

        public IEnumerable<TEntity> Items { get; set; }
    }
}
