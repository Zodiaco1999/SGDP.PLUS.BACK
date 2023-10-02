using Ardalis.GuardClauses;
using NetTopologySuite.Index.HPRtree;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using static SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio.GestionPerfilMenus;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

public class GestionUsuarioPerfil : BaseAppService, IGestionUsuarioPerfil
{
    private readonly IUsuarioPerfilRepositorioLectura _usuarioPerfilRepositorioLectura;
    private readonly IUsuarioPerfilRepositorioEscritura _usuarioPerfilRepositorioEscritura;
    private readonly IAplicationRepositorioLectura _aplicacionRepositorioLectura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuarioPerfil(
        IUsuarioPerfilRepositorioLectura usuarioPerfilRepositorioLectura,
        IUsuarioPerfilRepositorioEscritura usuarioPerfilRepositorioEscritura,
        IAplicationRepositorioLectura aplicationRepositorioLectura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuarioPerfilRepositorioLectura = usuarioPerfilRepositorioLectura;
        _usuarioPerfilRepositorioEscritura = usuarioPerfilRepositorioEscritura;
        _aplicacionRepositorioLectura = aplicationRepositorioLectura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }
    public async Task<DataViewModel<ConsultarUsuariosPerfilResponse>> ConsultarUsuariosPerfil(string usuarioId, Guid? aplicaionId, string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new UsuarioPerfilEspecificacion(usuarioId, aplicaionId, filtro);

            var result = await _usuarioPerfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .Include("Perfil.PerfilMenus")
                .SelectPageAsync(pagina, registrosPorPagina);

            var aplicaciones = await _aplicacionRepositorioLectura
                .Query()
                .SelectAsync();

            var consulta = new DataViewModel<ConsultarUsuariosPerfilResponse>(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarUsuariosPerfilResponse>();

            foreach (var item in result.Items!)
            {
                string nombreAplicacion = "N/A";

                if (item.Perfil.PerfilMenus.Count > 0)
                {
                    nombreAplicacion = aplicaciones.First(a => a.AplicacionId == item.Perfil.PerfilMenus.First().AplicacionId).NombreAplicacion;
                }

                consulta.Data.Add(new ConsultarUsuariosPerfilResponse(
                                item.UsuarioId,
                                item.PerfilId,
                                item.Perfil!.NombrePerfil,
                                nombreAplicacion,
                                item.FechaInicia,
                                item.FechaTermina,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha
                                ));
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(UsuarioPerfil), ex.Message);
        }
    }

    public async Task<CrearUsuarioPerfilResponse> CrearUsuarioPerfil(CrearUsuarioPerfilCommand registroDto)
    {
        var registro = new UsuarioPerfil()
        {
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
        return await _usuarioPerfilRepositorioLectura
             .Query(u => u.UsuarioId == usuarioId)
             .SelectAsync(up => new ConsultarUsuarioPerfilPorIdResponse(
                up.PerfilId,
                up.Perfil.NombrePerfil,
                up.Perfil.PerfilMenus.FirstOrDefault(p => p.PerfilId == up.PerfilId)!.Menu.Modulo.Apliation.NombreAplicacion ?? "NA",
                up.Perfil.DescPerfil,
                up.FechaInicia,
                up.FechaTermina,
                up.Perfil.Activo));
    }

    public async Task EditarUsuarioPerfil(List<EditarUsuarioPerfilCommand> usuarioPerfilDto, string usuarioId)
    {
        var usuarioPerfilActualizar = await _usuarioPerfilRepositorioEscritura
            .Query(x => x.UsuarioId == usuarioId)
            .SelectAsync();

        if (usuarioPerfilActualizar is null)
        {
            throw new NotFoundException(nameof(UsuarioPerfil), "No se encontro el registro");
        }

        var usuarioPerfilesActuales = usuarioPerfilDto
            .Select(u => new UsuarioPerfil
            {
                UsuarioId = usuarioId,
                PerfilId = u.PerfilId,
                FechaInicia = u.FechaInicia,
                FechaTermina = u.FechaTermina
            });

        var perfilesActuales = usuarioPerfilesActuales.Intersect(usuarioPerfilActualizar, new UsuarioPerfilEqualityComparer()).ToList();
        var perfilesAgregar = usuarioPerfilesActuales.Except(usuarioPerfilActualizar, new UsuarioPerfilEqualityComparer()).ToList();
        var perfilesEliminar = usuarioPerfilActualizar.Except(usuarioPerfilesActuales, new UsuarioPerfilEqualityComparer()).ToList();

        //Actuaizar elementos
        foreach (var perfilActual in perfilesActuales)
        {
            var perfilActualizar = usuarioPerfilActualizar.FirstOrDefault(up => up.PerfilId == perfilActual.PerfilId);
            if (perfilActualizar != null)
            {
                perfilActualizar.FechaInicia = perfilActual.FechaInicia;
                perfilActualizar.FechaTermina = perfilActual.FechaTermina;

                _usuarioPerfilRepositorioEscritura.Update(perfilActualizar);
            }
        }
        // Agregar elementos
        if (perfilesAgregar.Count > 0)
        {
            _usuarioPerfilRepositorioEscritura.InsertRange(perfilesAgregar);
        }
        // Eliminar elementos
        foreach (var perfilEliminar in perfilesEliminar)
        {
            await _usuarioPerfilRepositorioEscritura.DeleteAsync(perfilEliminar.UsuarioId, perfilEliminar.PerfilId);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public class UsuarioPerfilEqualityComparer : IEqualityComparer<UsuarioPerfil>
    {
        public bool Equals(UsuarioPerfil x, UsuarioPerfil y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return x.UsuarioId == y.UsuarioId &&
                   x.PerfilId == y.PerfilId;
        }

        public int GetHashCode(UsuarioPerfil obj)
        {
            unchecked
            {
                int hashCode = obj.UsuarioId.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.PerfilId.GetHashCode();
                return hashCode;
            }
        }
    }

}
