namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;

public record struct CrearPaisResponse(
    Guid PaisId,
    string? Nombre,
    string? Codigo,
    bool activo
    );