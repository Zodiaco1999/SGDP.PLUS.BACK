namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

public record struct ConsultarRespuestaLaftPorNitResponse(
    string CodigoInforma,
    string NumeroIdentificacion,
    string NombreTercero,
    DateTime FechaSolicitud,
    bool Alertado);