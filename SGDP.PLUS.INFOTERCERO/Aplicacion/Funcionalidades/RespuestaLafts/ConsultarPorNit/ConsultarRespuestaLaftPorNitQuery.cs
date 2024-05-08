using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

public record struct ConsultarRespuestaLaftPorNitQuery(
    GetEntityQuery Query,
    string Nit,
    bool Actualiza) : IRequest<DataViewModel<ConsultarRespuestaLaftPorNitResponse>>;