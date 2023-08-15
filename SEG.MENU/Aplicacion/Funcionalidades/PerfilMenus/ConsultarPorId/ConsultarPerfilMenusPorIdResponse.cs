namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public record struct ConsultarPerfilMenusPorIdResponse(
    Guid PerfilId,
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    string NombreMenu,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta,
    bool MenuConsulta,
    bool MenuInserta,
    bool MenuActualiza,
    bool MenuElimina,
    bool MenuActiva,
    bool MenuEjecuta);
