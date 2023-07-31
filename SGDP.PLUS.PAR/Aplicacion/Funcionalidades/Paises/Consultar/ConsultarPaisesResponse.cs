namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;

public record struct ConsultarPaisesResponse(
    Guid PaisId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );