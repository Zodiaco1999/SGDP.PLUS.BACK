namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;
public record struct ConsultarDetalleLaftResponse(
    string NumeroIdentificacion,
    string Nombre,
    string CodigoCargo,
    string Cargo,
    bool Alertado,
    DateTime? FechaNombramiento,
    DateTime? FechaCambioAdmin);

