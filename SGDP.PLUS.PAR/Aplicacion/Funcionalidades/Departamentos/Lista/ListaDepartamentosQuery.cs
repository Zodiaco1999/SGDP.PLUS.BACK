using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Lista;
public record struct ListaDepartamentosQuery() : IRequest<IEnumerable<ListaDepartamentosResponse>>;

