namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;

public record struct ConsultarIlicitosRespuestaPorIdResponse(
    Guid RespuestaLaftId,
    string Coincidencia,
    string PorcentajeCoincidencia,
    string ConsultaRealizada,
    string NombreEncontrado,
    string IdentificacionEncontrada,
    string Lista,
    string DelitoOcausa,
    string? Alias,
    string Fuente,
    string? FechaCarga,
    string Ciudad,
    string? FechaPublicacion,
    string Demandante,
    string Detalle);