using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;

public record struct CrearPaisCommand(
    string Nombre,
    string Codigo
    ) : IRequest<CrearPaisResponse>;