namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;

public record struct CrearCiudadResponse(
    Guid CiudadId,
    Guid? DepartamentoId,
    string Nombre,
    string Codigo,
    bool Avtivo
    );