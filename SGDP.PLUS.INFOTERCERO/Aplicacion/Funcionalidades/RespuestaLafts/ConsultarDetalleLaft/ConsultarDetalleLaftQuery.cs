using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;

public record struct ConsultarDetalleLaftQuery(string Nit, DateTime FechaSolicitud) : IRequest<IEnumerable<ConsultarDetalleLaftResponse>>;