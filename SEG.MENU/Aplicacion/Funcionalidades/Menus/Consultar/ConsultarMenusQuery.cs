using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

public record struct ConsultarMenusQuery(
    Guid AplicacionId, 
    Guid ModuloId,
    string TextoBusqueda, 
    int Pagina, 
    int RegistrosPorPagina) : IRequest<DataViewModel<ConsultarMenusResponse>>;