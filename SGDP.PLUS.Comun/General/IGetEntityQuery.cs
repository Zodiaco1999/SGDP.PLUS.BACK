
namespace SGDP.PLUS.Comun.General;

public interface IGetEntityQuery
{
    int Pagina { get; }
    int RegistrosPorPagina { get; }
    string TextoBusqueda { get; }
    string OrdenarPor { get; }
    string OrdenamientoAsc { get; }
}
