using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;

public record struct ConsultarIlicitosRespuestaPorIdQuery(Guid RespuestaLaftId, int Pagina, int RegistrosPorPagina, string OrdenarPor, bool OrdenamientoAsc)
    : IRequest<DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>>;