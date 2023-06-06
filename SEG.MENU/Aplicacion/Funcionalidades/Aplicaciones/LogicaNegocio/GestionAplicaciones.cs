﻿using Ardalis.GuardClauses;
using SEG.Comun.ContextAccesor;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

public class GestionAplicaciones : BaseAppService, IGestionAplicaciones
{
    private readonly IAplicationRepositorioLectura _aplicacionRepositorioLectura;
    private readonly IAplicationRepositorioEscritura _aplicacionRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionAplicaciones(
        IAplicationRepositorioLectura aplicacionRepositorioLectura,
        IAplicationRepositorioEscritura aplicacionRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _aplicacionRepositorioLectura = aplicacionRepositorioLectura;
        _aplicacionRepositorioEscritura = aplicacionRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarAplicacionesResponse>> ConsultarAplicaciones(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = false)
    {
        
        try
        {
            var filtroEspecificacion = new AplicacionEspecificacion(filtro);

            DataViewModel<ConsultarAplicacionesResponse> consulta = new DataViewModel<ConsultarAplicacionesResponse>();

            var result = await _aplicacionRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            consulta.TotalRecords = result.TotalItems;
            consulta.Data = new List<ConsultarAplicacionesResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarAplicacionesResponse(
                                item.AplicacionId,
                                item.NombreAplicacion,
                                item.DescAplicacion,
                                item.RutaUrl,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha
                                );
                consulta.Data.Add(det);
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Aplication), ex.Message);
        }
    }

    public async  Task<CrearAplicacionesResponse> CreaAplicacion(CrearAplicacionesCommand registroDto)
    {
        var registro = new Aplication()
        {
            NombreAplicacion = registroDto.NombreAplicacion,
            DescAplicacion = registroDto.DescAplicacion,
            RutaUrl = registroDto.RutaUrl
        };

        _aplicacionRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearAplicacionesResponse(registro.AplicacionId, registro.NombreAplicacion, registro.DescAplicacion, registro.RutaUrl, registro.Activo);
    }

    public async Task<EditarAplicacionesResponse> ActualizaAplicacion(EditarAplicacionesCommand registro)
    {
        var regActualizar = await _aplicacionRepositorioEscritura.Query(x => x.AplicacionId == registro.AplicacionId).FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualizar");
        regActualizar.NombreAplicacion = registro.NombreAplicacion;
        regActualizar.DescAplicacion = registro.DescAplicacion;
        regActualizar.RutaUrl = registro.RutaUrl;   

        _aplicacionRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _aplicacionRepositorioEscritura.Query(x => x.AplicacionId == registro.AplicacionId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualziado");
        }

        return new EditarAplicacionesResponse(
            regActualizado.AplicacionId,
            regActualizado.NombreAplicacion,
            regActualizado.DescAplicacion,
            regActualizado.RutaUrl,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

    public async Task<ConsultarAplicacionPorIdResponse> ConsultarAplicacion(Guid aplicacionId)
    {
        var result = await _aplicacionRepositorioLectura
                .Query(t => t.AplicacionId == aplicacionId)
                .Include(t => t.Modulos)
                .FirstOrDefaultAsync();

        result.Modulos.ForEach(m => m.Apliation = null!);

        var resp = new ConsultarAplicacionPorIdResponse(
            result.AplicacionId,
            result.NombreAplicacion,
            result.DescAplicacion,
            result.RutaUrl,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Modulos
            );
        
        return resp;
    }        

    public async Task<ActivarInactivarAplicacionesResponse> ActivarInactivar(Guid aplicacionId)
    {
        var regActualizar = await _aplicacionRepositorioEscritura.Query(x => x.AplicacionId == aplicacionId).FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualizar");
        regActualizar.Activo = !regActualizar.Activo;

        _aplicacionRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _aplicacionRepositorioEscritura.Query(x => x.AplicacionId == aplicacionId).FirstOrDefaultAsync(); ;
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Aplication), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarAplicacionesResponse(
            regActualizado.AplicacionId,
            regActualizado.NombreAplicacion,
            regActualizado.DescAplicacion,
            regActualizado.RutaUrl,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}
