using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;

public record struct ConsultarTipoDocumentoPorIdQuery(int TipoDocumentoId) : IRequest<ConsultarTipoDocumentoPorIdResponse>;