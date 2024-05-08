using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;

public record struct ConsultarPerfilesQuery(GetEntityQuery Query) : IRequest<DataViewModel<ConsultarPerfilesResponse>>;
