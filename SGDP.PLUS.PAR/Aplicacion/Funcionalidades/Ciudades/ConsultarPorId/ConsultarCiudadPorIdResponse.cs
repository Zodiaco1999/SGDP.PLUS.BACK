namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;

public record struct ConsultarCiudadPorIdResponse(
    Guid CiudadId,
    Guid? DepartamentoId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );