using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;

public record struct CrearRespuestaLaftCommand() : IRequest<CrearRespuestaLaftResponse>;