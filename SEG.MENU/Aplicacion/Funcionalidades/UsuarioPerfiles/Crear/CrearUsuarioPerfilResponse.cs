﻿namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

    public record struct CrearUsuarioPerfilResponse(
        string UsuarioId,
        Guid PerfilId,
        DateTime FechaInicia,
        DateTime FechaTermina);