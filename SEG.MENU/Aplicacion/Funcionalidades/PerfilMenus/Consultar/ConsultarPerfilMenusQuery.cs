using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public record struct ConsultarPerfilMenusQuery(
    Guid PerfilId, 
    Guid? AplicaionId, 
    Guid? ModuloId, 
    string TextoBusqueda, 
    int Pagina, 
    int RegistrosPorPagina) : IRequest<DataViewModel<ConsultarPerfilMenusResponse>>;
