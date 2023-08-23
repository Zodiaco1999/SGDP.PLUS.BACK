using Ardalis.GuardClauses;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Repositorio;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;
using System;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

public class GestionTipoPersonas : BaseAppService, IGestionTipoPersonas
{
    private readonly ITipoPersonaRepositorioLectura _tipopersonaRepositorioLectura;
    private readonly ITipoPersonaRepositorioEscritura _tipopersonaRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionTipoPersonas(
        ITipoPersonaRepositorioLectura tipopersonaRepositorioLectura,
        ITipoPersonaRepositorioEscritura tipopersonaRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _tipopersonaRepositorioLectura = tipopersonaRepositorioLectura;
        _tipopersonaRepositorioEscritura = tipopersonaRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarTipoPersonaResponse> ActivarInactivarTipoPersona(Guid tipopersonaId)
    {
        var regActualizar = await _tipopersonaRepositorioEscritura.Query(x => x.TipoPersonaId == tipopersonaId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _tipopersonaRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _tipopersonaRepositorioEscritura.Query(x => x.TipoPersonaId == tipopersonaId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarTipoPersonaResponse(
            regActualizado.TipoPersonaId,
            regActualizado.NombreTipo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<ConsultarTipoPersonaPorIdResponse> ConsultarTipoPersonaPorId(Guid tipopersonaId)
    {
        var result = await _tipopersonaRepositorioLectura.Query(p => p.TipoPersonaId == tipopersonaId).FirstOrDefaultAsync();


        return new ConsultarTipoPersonaPorIdResponse(
            result.TipoPersonaId,
            result.NombreTipo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Activo
            );
    
    }

    public async Task<DataViewModel<ConsultarTipoPersonasResponse>> ConsultarTipoPersonas(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new TipoPersonaEspecificacion(filtro);

            var result = await _tipopersonaRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarTipoPersonasResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarTipoPersonasResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarTipoPersonasResponse(
                                item.TipoPersonaId,
                                item.NombreTipo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha,
                                item.Activo
                                );
                consulta.Data.Add(det);
            }
            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(TipoPersona), ex.Message);
        }
    }

    public async Task<CrearTipoPersonaResponse> CrearTipoPersona(CrearTipoPersonaCommand registroDto)
    {
        var registro = new TipoPersona
        {
            NombreTipo = registroDto.NombreTipo
        };

        _tipopersonaRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearTipoPersonaResponse(
            registro.TipoPersonaId,
            registro.NombreTipo,
            registro.Activo
            );
    }

    public async Task<EditarTipoPersonaResponse> EditarTipoPersona(EditarTipoPersonaCommand registroDto)
    {
        var regActualizar = await _tipopersonaRepositorioEscritura.Query(x => x.TipoPersonaId == registroDto.TipoPersonaId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro a actualizar");
        }

        regActualizar.NombreTipo = registroDto.NombreTipo;

        _tipopersonaRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _tipopersonaRepositorioEscritura.Query(x => x.TipoPersonaId == registroDto.TipoPersonaId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new EditarTipoPersonaResponse(
            regActualizado.TipoPersonaId,
            regActualizado.NombreTipo,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    
    }
}