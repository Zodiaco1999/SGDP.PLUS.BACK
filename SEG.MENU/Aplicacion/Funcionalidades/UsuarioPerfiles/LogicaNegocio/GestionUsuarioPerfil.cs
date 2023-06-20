﻿using Ardalis.GuardClauses;
using SEG.Comun.ContextAccesor;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

public class GestionUsuarioPerfil : BaseAppService, IGestionUsuarioPerfil
{
    private readonly IUsuarioPerfilRepositorioLectura _usuarioPerfilRepositorioLectura;
    private readonly IUsuarioPerfilRepositorioEscritura _usuarioPerfilRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuarioPerfil(
        IUsuarioPerfilRepositorioLectura  usuarioPerfilRepositorioLectura,
        IUsuarioPerfilRepositorioEscritura usuarioPerfilRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuarioPerfilRepositorioLectura = usuarioPerfilRepositorioLectura;
        _usuarioPerfilRepositorioEscritura = usuarioPerfilRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }



    public async Task<DataViewModel<ConsultarUsuarioPerfilResponse>> ConsultarUsuariosPerfil(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new UsuarioPerfilEspecificacion(filtro);

            DataViewModel<ConsultarUsuarioPerfilResponse> consulta = new DataViewModel<ConsultarUsuarioPerfilResponse>();

            var result = await _usuarioPerfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            consulta.TotalRecords = result.TotalItems;
            consulta.Data = new List<ConsultarUsuarioPerfilResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarUsuarioPerfilResponse(
                                item.UsuarioId,
                                item.PerfilId,
                                item.FechaInicia,
                                item.FechaTermina,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha
                                );
                consulta.Data.Add(det);
            }
            return consulta;
        }
        catch(Exception ex) 
        {
            throw new NotFoundException(nameof(UsuarioPerfil), ex.Message);
        }
    }

    public async Task<CrearUsuarioPerfilResponse> CrearUsuarioPerfil(CrearUsuarioPerfilCommand registroDto)
    {
        var registro = new UsuarioPerfil()
        {
            UsuarioId = registroDto.UsuarioId,
            PerfilId = registroDto.PerfilId,
            FechaInicia = registroDto.FechaInicia,
            FechaTermina = registroDto.FechaTermina
        };

        _usuarioPerfilRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearUsuarioPerfilResponse(
            registro.UsuarioId,
            registro.PerfilId,
            registro.FechaInicia,
            registro.FechaTermina);
    }

    public async Task<ConsultarUsuarioPerfilPorIdResponse> ConsultarUsuarioPerfil(Guid perfilId, string usuarioId)
    {
        var result = await _usuarioPerfilRepositorioLectura
             .Query(p => p.PerfilId == perfilId && p.UsuarioId == usuarioId)
             .FirstOrDefaultAsync();

        return new ConsultarUsuarioPerfilPorIdResponse(
            result.UsuarioId,
            result.PerfilId,
            result.FechaInicia,
            result.FechaTermina,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<EditarUsuarioPerfilResponse> ActualizarUsuarioPerfil(EditarUsuarioPerfilCommand registroDto)
    {
        var regActualizar = await _usuarioPerfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(UsuarioPerfil), "No se encontro el registro");
        }

        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.PerfilId = registroDto.PerfilId;
        regActualizar.FechaInicia = registroDto.FechaInicia;
        regActualizar.FechaTermina = registroDto.FechaTermina;

        _usuarioPerfilRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuarioPerfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(UsuarioPerfil), "No se encontró el registro a actualizado");
        }

        return new EditarUsuarioPerfilResponse(
            regActualizado.UsuarioId,
            regActualizado.PerfilId,
            regActualizado.FechaInicia,
            regActualizado.FechaTermina,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}    
