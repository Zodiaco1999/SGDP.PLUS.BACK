﻿
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

public class GestionUsuariosFotos : BaseAppService, IGestionUsuariosFotos
{
    private readonly IUsuarioFotoRepositorioLectura _usuarioFotoRepositorioLectura;
    private readonly IUsuarioFotoRepositorioEscritura _usuarioFotoRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuariosFotos(
        IUsuarioFotoRepositorioLectura usuarioFotoRepositorioLectura,
        IUsuarioFotoRepositorioEscritura usuarioFotoRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuarioFotoRepositorioLectura = usuarioFotoRepositorioLectura;
        _usuarioFotoRepositorioEscritura = usuarioFotoRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarUsuariosFotosResponse>> ConsultarUsuariosFotos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new UsuarioFotoEspecificacion(filtro);

            var result = await _usuarioFotoRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarUsuariosFotosResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarUsuariosFotosResponse>();

            foreach (var item in result.Items)
            {
                var det = new ConsultarUsuariosFotosResponse(
                    item.UsuarioId,
                    item.Foto,
                    item.Formato,
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
            throw new BadRequestCustomException("Error consultando UsuariosFotos", ex);
        }
    }

    public async Task<ConsultarUsuarioFotoPorIdResponse> ConsultarUsuarioFotoPorId()
    {
        var result = await _usuarioFotoRepositorioLectura
            .FindAsync(ContextAccessor.UserId) ?? throw new NotFoundException(nameof(UsuarioFoto), ContextAccessor.UserId);

        return new ConsultarUsuarioFotoPorIdResponse($"{result.Formato},{result.Foto}");
    }

    public async Task<CrearUsuarioFotoResponse> CrearUsuarioFoto(CrearUsuarioFotoCommand registroDto)
    {
        var registro = new UsuarioFoto()
        {
            UsuarioId = registroDto.UsuarioId,
            Foto = registroDto.Foto,
            Formato = registroDto.Formato
        };

        _usuarioFotoRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearUsuarioFotoResponse(
            registro.UsuarioId,
            registro.Foto,
            registro.Formato);
    }

    public async Task<EditarUsuarioFotoResponse> EditarUsuarioFoto(EditarUsuarioFotoCommand registroDto)
    {
        var regActualizar = await _usuarioFotoRepositorioEscritura
            .Query(x => x.UsuarioId == registroDto.UsuarioId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioFoto), registroDto.UsuarioId);
       
        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.Foto = registroDto.Foto;
        regActualizar.Formato = registroDto.Formato;

        _usuarioFotoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuarioFotoRepositorioEscritura
            .Query(x => x.UsuarioId == registroDto.UsuarioId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioFoto), registroDto.UsuarioId);
        
        return new EditarUsuarioFotoResponse(
            regActualizado.UsuarioId,
            regActualizado.Foto,
            regActualizado.Formato,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

}
