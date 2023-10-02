using Ardalis.GuardClauses;
using NetTopologySuite.Index.HPRtree;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

public class GestionPerfiles : BaseAppService, IGestionPerfiles
{
    private readonly IPerfilRepositorioLectura _perfilRepositorioLectura;
    private readonly IPerfilRepositorioEscritura _perfilRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public GestionPerfiles(
        IPerfilRepositorioLectura perfilRepositorioLectura,
        IPerfilRepositorioEscritura perfilRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory,
        IGestionPerfilMenus gestionPerfilMenus
        ) : base(contextAccessor, loggerFactory)
    {
        _perfilRepositorioLectura = perfilRepositorioLectura;
        _perfilRepositorioEscritura = perfilRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
        _gestionPerfilMenus = gestionPerfilMenus;
    }

    public async Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PerfilEspecificacion(filtro);

            var result = await _perfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .Include("PerfilMenus.Menu.Modulo.Apliation")
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
                                item.PerfilMenus.FirstOrDefault() != null ?
                                item.PerfilMenus.FirstOrDefault()!.Menu.Modulo.Apliation.NombreAplicacion : "N/A",
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
        registro.PerfilMenus = registroDto.PerfilMenus.Select(pm => new PerfilMenu
        {
            AplicacionId = pm.AplicacionId,
            ModuloId = pm.ModuloId,
            MenuId = pm.MenuId,
            Consulta = pm.Consulta,
            Inserta = pm.Inserta,
            Actualiza = pm.Actualiza,
            Elimina = pm.Elimina,
            Activa = pm.Activa,
            Ejecuta = pm.Ejecuta
        }).ToList();

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
            .Include("PerfilMenus.Menu.Modulo.Apliation")
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Perfil), "No se encontró el registro");

        Guid aplicacionId = new();
        string nombreAplicacion = "N/A";
   
        var perfilmenu = result.PerfilMenus.FirstOrDefault();

        if (perfilmenu != null)
        {
            aplicacionId = perfilmenu.AplicacionId;
            nombreAplicacion = perfilmenu.Menu.Modulo.Apliation.NombreAplicacion;
        }

        return new ConsultarPerfilPorIdResponse(
            result.PerfilId,
            result.NombrePerfil,
            result.DescPerfil,
            aplicacionId,
            nombreAplicacion,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<EditarPerfilResponse> EditarPerfil(EditarPerfilCommand registroDto)
    {
        var regActualizar = await _perfilRepositorioEscritura
            .Query(x => x.PerfilId == registroDto.PerfilId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizar");

        regActualizar.NombrePerfil = registroDto.NombrePerfil;
        regActualizar.DescPerfil = registroDto.DescPerfil;

        _perfilRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        await _gestionPerfilMenus.EditarPerfilMenu(registroDto.perfilMenus, registroDto.PerfilId);

        var regActualizado = await _perfilRepositorioEscritura
            .Query(x => x.PerfilId == registroDto.PerfilId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Perfil), "No se encontró el registro actualizado");

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
