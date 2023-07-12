namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;

public record struct CrearPerfilMenuResponse( 
    Guid PerfilId,
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta);
    
