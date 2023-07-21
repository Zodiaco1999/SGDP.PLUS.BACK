namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public record struct ConsultarPerfilMenuPorIdResponse(
    Guid PerfilId,
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);
