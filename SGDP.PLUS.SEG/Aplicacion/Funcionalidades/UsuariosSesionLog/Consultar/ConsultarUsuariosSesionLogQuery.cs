using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public record struct ConsultarUsuariosSesionLogQuery(GetEntityQuery Query) : IRequest<DataViewModel<ConsultarUsuariosSesionLogResponse>>;