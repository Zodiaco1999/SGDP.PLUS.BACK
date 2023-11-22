using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

public record struct ConsultarModuloPorIdQuery(Guid moduloId) : IRequest<ConsultarModuloPorIdResponse>;