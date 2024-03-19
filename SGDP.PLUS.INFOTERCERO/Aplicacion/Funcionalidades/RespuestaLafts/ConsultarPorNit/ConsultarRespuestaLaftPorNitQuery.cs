using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

public record struct ConsultarRespuestaLaftPorNitQuery(
    string Nit,
    bool Actualiza,
    int Pagina,
    int RegistrosPorPagina) : IRequest<DataViewModel<ConsultarRespuestaLaftPorNitResponse>>;