using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;

public record struct CrearTipoDocumentoCommand(
    string Nombre,
    string Abreviatura
    ) : IRequest<CrearTipoDocumentoResponse>;