using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

public record struct ConsultarModuloPorIdQuery(Guid moduloId) : IRequest<ConsultarModuloPorIdResponse>;