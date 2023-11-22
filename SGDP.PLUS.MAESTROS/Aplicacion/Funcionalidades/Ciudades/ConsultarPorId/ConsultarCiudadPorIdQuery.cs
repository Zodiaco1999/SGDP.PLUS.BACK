using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;

public record struct ConsultarCiudadPorIdQuery(Guid CiudadId) : IRequest<ConsultarCiudadPorIdResponse>;