using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration.UserSecrets;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

public class GestionUsuarios : BaseAppService, IGestionUsuarios
{
    private readonly IUsuarioRepositorioLectura _usuarioRepositorioLectura;
    private readonly IUsuarioRepositorioEscritura _usuarioRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuarios(
        IUsuarioRepositorioLectura usuarioLectura,
        IUsuarioRepositorioEscritura usuarioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuarioRepositorioLectura = usuarioLectura;
        _usuarioRepositorioEscritura = usuarioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarUsuariosResponse>> ConsultarUsuarios(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new UsuarioEspecificacion(filtro);

            var result = await _usuarioRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarUsuariosResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarUsuariosResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarUsuariosResponse(
                                item.UsuarioId,
                                item.UsuarioDominio,
                                item.TipoDocumentoId,
                                item.NumeroIdentificacion,
                                item.PrimerNombre,
                                item.SegundoNombre,
                                item.PrimerApellido,
                                item.SegundoApellido,
                                item.Email,
                                item.FechaNacimiento,
                                item.Genero,
                                item.Contrasena,
                                item.FechaActualizacionContrasena,
                                item.AccesosFallidos,
                                item.FechaBloqueo,
                                item.CodigoAsignacion,
                                item.VenceCodigoAsignacion,
                                item.LogearLdap,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha);
                consulta.Data.Add(det);
            }
            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Usuario), ex.Message);
        }
    }

    public async Task<CrearUsuarioResponse> CrearUsuario(CrearUsuarioCommand registroDto)
    {
        //var usuarioExiste = await _usuarioRepositorioLectura
        //    .Query(q => q.Email == registroDto.Email)
        //    .FirstOrDefaultAsync();
        //if (usuarioExiste) throw new Exception("El usuario o el correo ya existe");

        var hash = Jwt.Hash(registroDto.Contrasena);
        var registro = new Usuario()
        {
            UsuarioId = registroDto.UsuarioId,
            UsuarioDominio = registroDto.UsuarioDominio,
            TipoDocumentoId = registroDto.TipoDocumentoId,
            NumeroIdentificacion = registroDto.NumeroIdentificacion,
            PrimerNombre = registroDto.PrimerNombre,
            SegundoNombre = registroDto.SegundoNombre,
            PrimerApellido = registroDto.PrimerApellido,
            SegundoApellido = registroDto.SegundoApellido,
            Email = registroDto.Email,
            FechaNacimiento = registroDto.FechaNacimiento,
            Genero = registroDto.Genero,
            Contrasena = hash.Password,
            Salt = hash.Salt,
            FechaActualizacionContrasena = registroDto.FechaActualizacionContrasena,
            AccesosFallidos = registroDto.AccesosFallidos,
            FechaBloqueo = registroDto.FechaBloqueo,
            CodigoAsignacion = registroDto.CodigoAsignacion,
            VenceCodigoAsignacion = registroDto.VenceCodigoAsignacion,

        };

        _usuarioRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearUsuarioResponse(
            registro.UsuarioId,
            registro.UsuarioDominio,
            registro.TipoDocumentoId,
            registro.NumeroIdentificacion,
            registro.PrimerNombre,
            registro.SegundoNombre,
            registro.PrimerApellido,
            registro.SegundoApellido,
            registro.Email,
            registro.FechaNacimiento,
            registro.Genero,
            registro.Contrasena,
            registro.FechaActualizacionContrasena,
            registro.AccesosFallidos,
            registro.FechaBloqueo,
            registro.CodigoAsignacion,
            registro.VenceCodigoAsignacion,
            registro.LogearLdap,
            registro.Activo);
    }
    public async Task<ConsultarUsuarioPorIdResponse> ConsultarUsuarioPorId(string usuarioId)
    {
        var result = await _usuarioRepositorioLectura
              .Query(p => p.UsuarioId == usuarioId)
              .FirstOrDefaultAsync();

        return new ConsultarUsuarioPorIdResponse(
            result.UsuarioId,
            result.UsuarioDominio,
            result.TipoDocumentoId,
            result.NumeroIdentificacion,
            result.PrimerNombre,
            result.SegundoNombre,
            result.PrimerApellido,
            result.SegundoApellido,
            result.Email,
            result.FechaNacimiento,
            result.Genero,
            result.Contrasena,
            result.FechaActualizacionContrasena,
            result.AccesosFallidos,
            result.FechaBloqueo,
            result.CodigoAsignacion,
            result.VenceCodigoAsignacion,
            result.LogearLdap,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<EditarUsuarioResponse> EditarUsuario(EditarUsuarioCommand registroDto)
    {
        var regActualizar = await _usuarioRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Usuario), "No se encontro el registro");
        }

        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.UsuarioDominio = registroDto.UsuarioDominio;
        regActualizar.UsuarioDominio = registroDto.UsuarioDominio;
        regActualizar.TipoDocumentoId = registroDto.TipoDocumentoId;
        regActualizar.NumeroIdentificacion = registroDto.NumeroIdentificacion;
        regActualizar.PrimerNombre = registroDto.PrimerNombre;
        regActualizar.SegundoNombre = registroDto.SegundoNombre;
        regActualizar.PrimerApellido = registroDto.PrimerApellido;
        regActualizar.SegundoApellido = registroDto.SegundoApellido;
        regActualizar.Email = registroDto.Email;
        regActualizar.FechaNacimiento = registroDto.FechaNacimiento;
        regActualizar.Genero = registroDto.Genero;
        regActualizar.Contrasena = registroDto.Contrasena;
        regActualizar.FechaActualizacionContrasena = registroDto.FechaActualizacionContrasena;
        regActualizar.AccesosFallidos = registroDto.AccesosFallidos;
        regActualizar.FechaBloqueo = registroDto.FechaBloqueo;
        regActualizar.CodigoAsignacion = registroDto.CodigoAsignacion;
        regActualizar.VenceCodigoAsignacion = registroDto.VenceCodigoAsignacion;


        _usuarioRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuarioRepositorioEscritura.Query(x => x.UsuarioId == registroDto.UsuarioId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Usuario), "No se encontró el registro a actualizado");
        }

        return new EditarUsuarioResponse(
            regActualizado.UsuarioId,
            regActualizado.UsuarioDominio,
            regActualizado.TipoDocumentoId,
            regActualizado.NumeroIdentificacion,
            regActualizado.PrimerNombre,
            regActualizado.SegundoNombre,
            regActualizado.PrimerApellido,
            regActualizado.SegundoApellido,
            regActualizado.Email,
            regActualizado.FechaNacimiento,
            regActualizado.Genero,
            regActualizado.Contrasena,
            regActualizado.FechaActualizacionContrasena,
            regActualizado.AccesosFallidos,
            regActualizado.FechaBloqueo,
            regActualizado.CodigoAsignacion,
            regActualizado.VenceCodigoAsignacion,
            regActualizado.LogearLdap,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

    public async Task<ActivarInactivarUsuarioResponse> ActivarInactivarUsuario(string usuarioId)
    {
        var regActualizar = await _usuarioRepositorioEscritura.Query(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Usuario), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _usuarioRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuarioRepositorioEscritura.Query(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Usuario), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarUsuarioResponse(
            regActualizado.UsuarioId,
            regActualizado.UsuarioDominio,
            regActualizado.TipoDocumentoId,
            regActualizado.NumeroIdentificacion,
            regActualizado.PrimerNombre,
            regActualizado.SegundoNombre,
            regActualizado.PrimerApellido,
            regActualizado.SegundoApellido,
            regActualizado.Email,
            regActualizado.FechaNacimiento,
            regActualizado.Genero,
            regActualizado.Contrasena,
            regActualizado.FechaActualizacionContrasena,
            regActualizado.AccesosFallidos,
            regActualizado.FechaBloqueo,
            regActualizado.CodigoAsignacion,
            regActualizado.VenceCodigoAsignacion,
            regActualizado.LogearLdap,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}