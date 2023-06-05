﻿namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public record struct ConsultarPerfilMenusResponse(
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
