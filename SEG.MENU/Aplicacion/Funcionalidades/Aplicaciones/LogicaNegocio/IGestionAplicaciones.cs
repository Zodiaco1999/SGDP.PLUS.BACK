﻿using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

public interface IGestionAplicaciones
{
    Task<DataViewModel<ConsultarAplicacionesResponse>> ConsultarAplicaciones(string filtro, int pagina, int registrosPorPagina, string? ordenarPor=null, bool? direccionOrdenamientoAsc=null);

    Task<ConsultarAplicacionPorIdResponse> ConsultarAplicacion(Guid aplicacionId);

    Task<CrearAplicacionesResponse> CreaAplicacion(CrearAplicacionesCommand registroDto);

    Task<EditarAplicacionesResponse> ActualizaAplicacion(EditarAplicacionesCommand registroDto);

    Task<ActivarInactivarAplicacionesResponse> ActivarInactivar(Guid aplicacionId);
}
