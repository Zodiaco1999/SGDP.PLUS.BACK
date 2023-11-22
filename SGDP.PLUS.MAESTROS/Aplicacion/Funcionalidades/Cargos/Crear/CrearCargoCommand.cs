using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;

public record struct CrearCargoCommand(
    string? Nombre,
    string? Abreviatura
    ) : IRequest<CrearCargoResponse>;