using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Lista;
public record struct ListaTipoDocumentoQuery() : IRequest<IEnumerable<ListaTipoDocumentoResponse>>;