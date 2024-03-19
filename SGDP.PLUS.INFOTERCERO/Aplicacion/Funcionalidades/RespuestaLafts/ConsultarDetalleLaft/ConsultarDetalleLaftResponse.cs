namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;
public record struct ConsultarDetalleLaftResponse(
    Guid RespuestaLaftId,
    string NumeroIdentificacion,
    string Nombre,
    string CodigoCargo,
    string Cargo,
    DateTime? FechaNombramiento,
    DateTime? FechaCambioAdmin);

