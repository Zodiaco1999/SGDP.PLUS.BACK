using Ardalis.GuardClauses;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

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



    public async Task<DataViewModel<ConsultarUsuariosPerfilResponse>> ConsultarUsuariosPerfil(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new UsuarioPerfilEspecificacion(filtro);

            var result = await _usuarioPerfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarUsuariosPerfilResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarUsuariosPerfilResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarUsuariosPerfilResponse(
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

    public async Task<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>> ConsultarUsuarioPerfilPorId(string usuarioId)
    {
        var perfiles = _usuarioPerfilRepositorioLectura
            .Query(u => u.UsuarioId == usuarioId)
            .Include(p => p.Perfil)
            .Select(p => p.Perfil);

        var perfilesResponse = new List<ConsultarUsuarioPerfilPorIdResponse>();

        foreach(var perfil in perfiles)
        {
            perfilesResponse.Add(new ConsultarUsuarioPerfilPorIdResponse(
                perfil.PerfilId, 
                perfil.NombrePerfil, 
                perfil.DescPerfil, 
                perfil.Activo));
        }

        return perfilesResponse;
    }

    public async Task<EditarUsuarioPerfilResponse> EditarUsuarioPerfil(EditarUsuarioPerfilCommand registroDto)
    {
        var regActualizar = await _usuarioPerfilRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId && x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();

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

        var regActualizado = await _usuarioPerfilRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId && x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();
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
