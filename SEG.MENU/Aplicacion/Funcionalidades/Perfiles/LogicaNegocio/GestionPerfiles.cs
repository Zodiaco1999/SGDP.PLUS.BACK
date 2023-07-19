using Ardalis.GuardClauses;
using SEG.Comun.ContextAccesor;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

public class GestionPerfiles : BaseAppService, IGestionPerfiles
{
    private readonly IPerfilRepositorioLectura _perfilRepositorioLectura;
    private readonly IPerfilRepositorioEscritura _perfilRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionPerfiles(
        IPerfilRepositorioLectura perfilRepositorioLectura,
        IPerfilRepositorioEscritura perfilRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _perfilRepositorioLectura = perfilRepositorioLectura;
        _perfilRepositorioEscritura = perfilRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PerfilEspecificacion(filtro);

            var result = await _perfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarPerfilesResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarPerfilesResponse>();

            foreach (var item in result.Items!)
            {
                consulta.Data.Add(new ConsultarPerfilesResponse(
                                item.PerfilId,
                                item.NombrePerfil,
                                item.DescPerfil,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha));
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Perfil), ex.Message);
        }
    }

    public async Task<CrearPerfilResponse> CrearPerfil(CrearPerfilCommand registroDto)
    {
        var registro = new Perfil { NombrePerfil = registroDto.NombrePerfil, DescPerfil = registroDto.DescPerfil };

        _perfilRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearPerfilResponse(registro.PerfilId, registro.NombrePerfil, registro.DescPerfil, registro.Activo);
    }

    public async Task<ActivarInactivarPerfilResponse> ActivarInactivarPerfil(Guid perfilId)
    {
        var regActualizar = await _perfilRepositorioEscritura.Query(x => x.PerfilId == perfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _perfilRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _perfilRepositorioEscritura.Query(x => x.PerfilId == perfilId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarPerfilResponse(
            regActualizado.PerfilId,
            regActualizado.NombrePerfil,
            regActualizado.DescPerfil,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

    public async Task<ConsultarPerfilPorIdResponse> ConsultarPerfilPorId(Guid perfilId)
    {
        var result = await _perfilRepositorioLectura
            .Query(p => p.PerfilId == perfilId)
            .Include(p => p.PerfilMenu!)
            //.Include(p => p.UsuarioPerfiles)
            .FirstOrDefaultAsync();

        if (result.PerfilMenu is not null) result.PerfilMenu.Perfil = null!;

        return new ConsultarPerfilPorIdResponse(
            result.PerfilId,
            result.NombrePerfil,
            result.DescPerfil,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.PerfilMenu);
    }

    public async Task<EditarPerfilResponse> EditarPerfil(EditarPerfilCommand registroDto)
    {
        var regActualizar = await _perfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizar");
        }

        regActualizar.NombrePerfil = registroDto.NombrePerfil;
        regActualizar.DescPerfil = registroDto.DescPerfil;

        _perfilRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _perfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro actualizado");
        }

        return new EditarPerfilResponse(
            regActualizado.PerfilId,
            regActualizado.NombrePerfil,
            regActualizado.DescPerfil,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}
