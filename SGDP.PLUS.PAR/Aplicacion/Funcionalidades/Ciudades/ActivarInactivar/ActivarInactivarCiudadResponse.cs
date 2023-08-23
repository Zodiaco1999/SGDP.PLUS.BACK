namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;

public record struct ActivarInactivarCiudadResponse(
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