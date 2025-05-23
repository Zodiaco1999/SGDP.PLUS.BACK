﻿using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Lista;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

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

    public async Task<DataViewModel<ConsultarAplicacionesResponse>> ConsultarAplicaciones(GetEntityQuery query)
    {
        try
        {
            var filtroEspecificacion = new AplicacionEspecificacion(query.TextoBusqueda);

            var result = await _aplicacionRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
                .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

            DataViewModel<ConsultarAplicacionesResponse> consulta = new DataViewModel<ConsultarAplicacionesResponse>(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

            consulta.Data = result.Items.Select(item => new ConsultarAplicacionesResponse(
                                item.AplicacionId,
                                item.NombreAplicacion,
                                item.DescAplicacion,
                                item.RutaUrl,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha)).ToList();

            return consulta;
        }
        catch (Exception ex)
        {
            throw new BadRequestCustomException("Error consultando aplicaciones", ex);
        }
    }

    public async Task<ConsultarAplicacionPorIdResponse> ConsultarAplicacionPorId(Guid aplicacionId)
    {
        var result = await _aplicacionRepositorioLectura
                .Query(t => t.AplicacionId == aplicacionId)
                .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), aplicacionId);

        return new ConsultarAplicacionPorIdResponse(
            result.AplicacionId,
            result.NombreAplicacion,
            result.DescAplicacion,
            result.RutaUrl,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<CrearAplicacionResponse> CrearAplicacion(CrearAplicacionCommand registroDto)
    {
        var registro = new Aplication()
        {
            NombreAplicacion = registroDto.NombreAplicacion,
            DescAplicacion = registroDto.DescAplicacion,
            RutaUrl = registroDto.RutaUrl
        };

        _aplicacionRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearAplicacionResponse(registro.AplicacionId, registro.NombreAplicacion, registro.DescAplicacion, registro.RutaUrl, registro.Activo);
    }

    public async Task<EditarAplicacionResponse> EditarAplicacion(EditarAplicacionCommand registro)
    {
        var regActualizar = await _aplicacionRepositorioEscritura
            .Query(x => x.AplicacionId == registro.AplicacionId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), registro.AplicacionId);

        regActualizar.NombreAplicacion = registro.NombreAplicacion;
        regActualizar.DescAplicacion = registro.DescAplicacion;
        regActualizar.RutaUrl = registro.RutaUrl;

        _aplicacionRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _aplicacionRepositorioEscritura
            .Query(x => x.AplicacionId == registro.AplicacionId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), registro.AplicacionId);

        return new EditarAplicacionResponse(
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

    public async Task<ActivarInactivarAplicacionResponse> ActivarInactivarAplicacion(Guid aplicacionId)
    {
        var regActualizar = await _aplicacionRepositorioEscritura
            .Query(x => x.AplicacionId == aplicacionId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), aplicacionId);

        regActualizar.Activo = !regActualizar.Activo;

        _aplicacionRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _aplicacionRepositorioEscritura
            .Query(x => x.AplicacionId == aplicacionId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Aplication), aplicacionId);

        return new ActivarInactivarAplicacionResponse(
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

    public async Task<IEnumerable<ListaAplicacionesResponse>> ListaAplicaciones()
    {
        return await _aplicacionRepositorioLectura
            .Query(a => a.Activo)
            .OrderBy("NombreAplicacion")
            .SelectAsync(a => new ListaAplicacionesResponse(
                a.AplicacionId,
                a.NombreAplicacion,
                a.DescAplicacion,
                a.RutaUrl,
                a.Activo));
    }
}
