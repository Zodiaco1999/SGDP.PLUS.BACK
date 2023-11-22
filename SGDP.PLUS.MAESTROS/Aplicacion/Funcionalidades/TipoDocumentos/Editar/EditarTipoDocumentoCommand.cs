using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;

public record struct EditarTipoDocumentoCommand(int TipoDocumentoId, string Nombre, string Abreviatura) : IRequest<EditarTipoDocumentoResponse>;