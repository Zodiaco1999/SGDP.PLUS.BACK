namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;

public record struct ListaPaisesResponse(
    Guid PaisId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo);