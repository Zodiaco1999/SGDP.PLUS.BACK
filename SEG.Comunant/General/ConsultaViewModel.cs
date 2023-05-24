using System.Collections.Generic;

namespace SEG.Comun.General
{
    public class ConsultaViewModel<T>
    {
        public List<T> Items { get; set; }

        public int TotalRegistros { get; set; }
    }
}
