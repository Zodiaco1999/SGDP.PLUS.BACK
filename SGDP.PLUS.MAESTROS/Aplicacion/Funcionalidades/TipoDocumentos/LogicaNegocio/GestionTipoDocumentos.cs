using SGDP.PLUS.Comun.Excepcion;
using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Lista;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Repositorio;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

public class GestionTipoDocumentos : BaseAppService, IGestionTipoDocumentos
{
    private readonly ITipoDocumentoRepositorioLectura _tipodocumentoRepositorioLectura;
    private readonly ITipoDocumentoRepositorioEscritura _tipodocumentoRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionTipoDocumentos(
        ITipoDocumentoRepositorioLectura tipodocumentoRepositorioLectura,
        ITipoDocumentoRepositorioEscritura tipodocumentoRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _tipodocumentoRepositorioLectura = tipodocumentoRepositorioLectura;
        _tipodocumentoRepositorioEscritura = tipodocumentoRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarTipoDocumentoResponse> ActivarInactivarTipoDocumento(int tipodocumentoId)
    {
        var regActualizar = await _tipodocumentoRepositorioEscritura.Query(x => x.TipoDocumentoId == tipodocumentoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _tipodocumentoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _tipodocumentoRepositorioEscritura.Query(x => x.TipoDocumentoId == tipodocumentoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarTipoDocumentoResponse(
            regActualizado.TipoDocumentoId,
            regActualizado.Nombre,
            regActualizado.Abreviatura,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<ConsultarTipoDocumentoPorIdResponse> ConsultarTipoDocumentoPorId(int tipodocumentoId)
    {
        var result = await _tipodocumentoRepositorioLectura.Query(p => p.TipoDocumentoId == tipodocumentoId).FirstOrDefaultAsync();


        return new ConsultarTipoDocumentoPorIdResponse(
            result.TipoDocumentoId,
            result.Nombre,
            result.Abreviatura,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Activo
            );

    }

    public async Task<DataViewModel<ConsultarTipoDocumentosResponse>> ConsultarTipoDocumentos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new TipoDocumentoEspecificacion(filtro);

            var result = await _tipodocumentoRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarTipoDocumentosResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarTipoDocumentosResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarTipoDocumentosResponse(
                                item.TipoDocumentoId,
                                item.Nombre,
                                item.Abreviatura,
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
            throw new NotFoundException(nameof(TipoDocumento), ex.Message);
        }
    }

    public async Task<CrearTipoDocumentoResponse> CrearTipoDocumento(CrearTipoDocumentoCommand registroDto)
    {
        var registro = new TipoDocumento
        {
            TipoDocumentoId =  _tipodocumentoRepositorioLectura.Query().Select().Count()+1, 
            Nombre = registroDto.Nombre,
            Abreviatura = registroDto.Abreviatura
        };

        _tipodocumentoRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearTipoDocumentoResponse(
            registro.TipoDocumentoId,
            registro.Nombre,
            registro.Abreviatura,
            registro.Activo
            );
    }

    public async Task<EditarTipoDocumentoResponse> EditarTipoDocumento(EditarTipoDocumentoCommand registroDto)
    {
        var regActualizar = await _tipodocumentoRepositorioEscritura.Query(x => x.TipoDocumentoId == registroDto.TipoDocumentoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoDocumento), "No se encontró el registro a actualizar");
        }

        regActualizar.Nombre = registroDto.Nombre;
        regActualizar.Abreviatura = registroDto.Abreviatura;

        _tipodocumentoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _tipodocumentoRepositorioEscritura.Query(x => x.TipoDocumentoId == registroDto.TipoDocumentoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new EditarTipoDocumentoResponse(
            regActualizado.TipoDocumentoId,
            regActualizado.Nombre,
            regActualizado.Abreviatura,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );

    }

    public async Task<IEnumerable<ListaTipoDocumentoResponse>> ListaTipoDocumento()
    {
        var tipoDocumento = await _tipodocumentoRepositorioLectura
            .Queryable()
            .ToListAsync();

        IEnumerable<ListaTipoDocumentoResponse> response = tipoDocumento.Select(t => new ListaTipoDocumentoResponse(
            t.TipoDocumentoId,
            t.Nombre,
            t.Abreviatura,
            t.Activo));

        return response;
    }
}