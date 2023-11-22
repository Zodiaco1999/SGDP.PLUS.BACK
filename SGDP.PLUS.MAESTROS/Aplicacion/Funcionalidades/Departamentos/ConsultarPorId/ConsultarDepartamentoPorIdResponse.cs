namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;

public record struct ConsultarDepartamentoPorIdResponse(
    Guid DepartamentoId,
    Guid? PaisId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );