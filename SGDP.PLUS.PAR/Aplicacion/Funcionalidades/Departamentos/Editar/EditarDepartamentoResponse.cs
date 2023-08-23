namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;

public record struct EditarDepartamentoResponse(
    Guid DepartamentoId,
    Guid? PaisId,
    string? Nombre,
    string? Codigo,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );