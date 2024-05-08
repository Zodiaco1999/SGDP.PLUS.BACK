using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public record struct ConsultarAplicacionesQuery(GetEntityQuery Query) : IRequest<DataViewModel<ConsultarAplicacionesResponse>>;
