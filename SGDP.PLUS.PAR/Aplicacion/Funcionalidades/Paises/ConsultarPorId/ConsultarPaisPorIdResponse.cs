namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;

public record struct ConsultarPaisPorIdResponse(
    Guid PaisId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );