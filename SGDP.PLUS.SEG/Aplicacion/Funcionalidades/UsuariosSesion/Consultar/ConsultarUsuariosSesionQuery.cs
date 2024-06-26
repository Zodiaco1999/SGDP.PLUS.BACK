using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;

public record struct ConsultarUsuariosSesionQuery(GetEntityQuery Query) : IRequest<DataViewModel<ConsultarUsuariosSesionResponse>>;