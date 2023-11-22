using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;

public record struct CrearCiudadCommand(
    Guid? DepertamentoId,
    string Nombre,
    string Codigo) : IRequest<CrearCiudadResponse>;