﻿using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

public interface IGestionAplicaciones
{
    Task<DataViewModel<ConsultarAplicacionesResponse>> ConsultarAplicaciones(string filtro, int pagina, int registrosPorPagina, string? ordenarPor=null, bool? direccionOrdenamientoAsc=null);

    Task<ConsultarAplicacionPorIdResponse> ConsultarAplicacionPorId(Guid aplicacionId);

    Task<CrearAplicacionResponse> CrearAplicacion(CrearAplicacionCommand registroDto);

    Task<EditarAplicacionResponse> EditarAplicacion(EditarAplicacionCommand registroDto);

    Task<ActivarInactivarAplicacionResponse> ActivarInactivarAplicacion(Guid aplicacionId);
}
