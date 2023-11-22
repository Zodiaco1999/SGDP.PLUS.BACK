using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;

public record struct ActivarInactivarCiudadCommand(Guid CiudadID) : IRequest<ActivarInactivarCiudadResponse>;