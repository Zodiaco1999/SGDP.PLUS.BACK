using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Lista;

public record struct ListaAplicacionesQuery() : IRequest<IEnumerable<ListaAplicacionesResponse>>;
