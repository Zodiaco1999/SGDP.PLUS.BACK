namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Lista;

    public record struct ListaDepartamentosResponse(
    Guid DepartamentoId,
    string? Nombre,
    string? Codigo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo);
    

