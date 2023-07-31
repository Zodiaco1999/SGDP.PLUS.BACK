using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

public interface IGestionTipoDocumentos
{
    Task<DataViewModel<ConsultarTipoDocumentosResponse>> ConsultarTipoDocumentos(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarTipoDocumentoPorIdResponse> ConsultarTipoDocumentoPorId(int tipodocumentoId);
    Task<CrearTipoDocumentoResponse> CrearTipoDocumento(CrearTipoDocumentoCommand registroDto);
    Task<EditarTipoDocumentoResponse> EditarTipoDocumento(EditarTipoDocumentoCommand registroDto);
    Task<ActivarInactivarTipoDocumentoResponse> ActivarInactivarTipoDocumento(int tipodocumentoId);
}