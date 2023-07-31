namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;

public record struct EditarCiudadResponse(
    Guid CiudadId,
    Guid? DepartamentoId,
    string? Nombre,
    string? Codigo,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );