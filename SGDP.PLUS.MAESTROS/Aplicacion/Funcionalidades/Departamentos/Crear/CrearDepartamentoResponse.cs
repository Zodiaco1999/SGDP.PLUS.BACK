namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;

public record struct CrearDepartamentoResponse(
    Guid DepartamentoId,
    Guid? PaisId,
    string Nombre,
    string Codigo,
    bool Avtivo
    );