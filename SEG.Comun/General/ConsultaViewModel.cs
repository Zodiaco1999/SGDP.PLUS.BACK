using System.Collections.Generic;

namespace SGDP.PLUS.Comun.General;

public class ConsultaViewModel<T>
{
    public List<T>? Items { get; set; }

    public int TotalRegistros { get; set; }
}
