using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;

public record struct ConsultarCargoPorIdQuery(Guid CargoId) : IRequest<ConsultarCargoPorIdResponse>;