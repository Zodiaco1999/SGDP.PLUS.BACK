using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Lista;

public record struct ListaTipoDocumentoQuery() : IRequest<IEnumerable<ListaTipoDocumentoResponse>>;

