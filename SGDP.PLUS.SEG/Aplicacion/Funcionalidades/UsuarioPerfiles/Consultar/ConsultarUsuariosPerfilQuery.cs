using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

public record struct ConsultarUsuariosPerfilQuery(
    string UsuarioId,
    Guid? PerfilId,
    Guid? AplicaionId,
    string TextoBusqueda, 
    int Pagina, 
    int RegistrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosPerfilResponse>>;

