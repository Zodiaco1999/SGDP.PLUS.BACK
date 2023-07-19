using Ardalis.GuardClauses;
using SEG.Comun.ContextAccesor;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

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

            foreach (var item in result.Items!)
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
            throw new NotFoundException(nameof(UsuarioFoto), ex.Message);
        }
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

    public async Task<ConsultarUsuarioFotoPorIdResponse> ConsultarUsuarioFotoPorId(string usuarioId)
    {
        var result = await _usuarioFotoRepositorioLectura
              .Query(p => p.UsuarioId == usuarioId)
              .FirstOrDefaultAsync();

        return new ConsultarUsuarioFotoPorIdResponse(
            result.UsuarioId,
            result.Foto,
            result.Formato,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }


    public async Task<EditarUsuarioFotoResponse> EditarUsuarioFoto(EditarUsuarioFotoCommand registroDto)
    {
        var regActualizar = await _usuarioFotoRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(UsuarioFoto), "No se encontro el registro");
        }

        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.Foto = registroDto.Foto;
        regActualizar.Formato = registroDto.Formato;

        _usuarioFotoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuarioFotoRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(UsuarioFoto), "No se encontró el registro a actualizado");
        }

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
