using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;

public record struct EditarRespuestaLaftCommand() : IRequest<EditarRespuestaLaftResponse>;