using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;

public record struct ConsultarDepartamentoPorIdQuery(Guid DepartamentoId) : IRequest<ConsultarDepartamentoPorIdResponse>;