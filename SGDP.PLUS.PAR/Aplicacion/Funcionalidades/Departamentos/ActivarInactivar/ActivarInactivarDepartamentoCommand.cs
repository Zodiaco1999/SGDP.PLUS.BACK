using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ActivarInactivar;

public record struct ActivarInactivarDepartamentoCommand(Guid DepartamentoId) : IRequest<ActivarInactivarDepartamentoResponse>;