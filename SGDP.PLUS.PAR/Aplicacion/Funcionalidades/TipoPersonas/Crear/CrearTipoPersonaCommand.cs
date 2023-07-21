using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;

public record struct CrearTipoPersonaCommand(
        string NombreTipo
    ) : IRequest<CrearTipoPersonaResponse>;