namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;

public record struct ActivarInactivarPaisResponse(
    Guid PaisId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );