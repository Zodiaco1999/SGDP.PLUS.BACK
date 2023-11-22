using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;

public record struct ListaPaisesQuery() : IRequest<IEnumerable<ListaPaisesResponse>>;