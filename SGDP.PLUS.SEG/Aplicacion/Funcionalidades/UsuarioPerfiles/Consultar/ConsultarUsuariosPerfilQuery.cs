using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

public record struct ConsultarUsuariosPerfilQuery(
    GetEntityQuery Query,
    Guid? AplicaionId) : IRequest<DataViewModel<ConsultarUsuariosPerfilResponse>>;

