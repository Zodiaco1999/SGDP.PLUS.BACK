using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;

public record struct ActivarInactivarTipoDocumentoCommand(int TipoDocumentoId) : IRequest<ActivarInactivarTipoDocumentoResponse>;