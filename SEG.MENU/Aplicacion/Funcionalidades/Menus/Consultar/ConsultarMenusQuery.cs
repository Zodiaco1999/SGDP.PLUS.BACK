using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Consultar;

public record struct ConsultarMenusQuery(
    Guid AplicacionId, 
    Guid ModuloId,
    string TextoBusqueda, 
    int Pagina, 
    int RegistrosPorPagina) : IRequest<DataViewModel<ConsultarMenusResponse>>;