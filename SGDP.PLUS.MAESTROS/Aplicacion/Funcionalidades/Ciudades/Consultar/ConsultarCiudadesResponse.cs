namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;

public record struct ConsultarCiudadesResponse(
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