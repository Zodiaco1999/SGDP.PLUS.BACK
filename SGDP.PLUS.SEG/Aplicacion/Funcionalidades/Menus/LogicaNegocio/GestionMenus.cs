using LinqKit;
using NetTopologySuite.Index.HPRtree;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System.Linq;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

public class GestionMenus : BaseAppService, IGestionMenus
{
    private readonly IMenuRepositorioLectura _menuRepositorioLectura;
    private readonly IMenuRepositorioEscritura _menuRepositorioEscritura;
    private readonly IAplicationRepositorioLectura _aplicacionRepositorioLectura;
    private readonly IPerfilMenuRepositorioLectura _perfilMenuRepositorioLectura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionMenus(
        IMenuRepositorioLectura menuRepositorioLectura,
        IMenuRepositorioEscritura menuRepositorioEscritura,
        IAplicationRepositorioLectura aplicacionRepositorioLectura,
        IPerfilMenuRepositorioLectura perfilMenuRepositorioLectura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _menuRepositorioLectura = menuRepositorioLectura;
        _menuRepositorioEscritura = menuRepositorioEscritura;
        _aplicacionRepositorioLectura = aplicacionRepositorioLectura;
        _perfilMenuRepositorioLectura = perfilMenuRepositorioLectura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarMenuResponse> ActivarInactivarMenu(Guid menuId)
    {
        var regActualizar = await _menuRepositorioLectura
            .Query(m => m.MenuId == menuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), menuId);

        regActualizar.Activo = !regActualizar.Activo;

        _menuRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _menuRepositorioLectura
            .Query(m => m.MenuId == menuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("No se encontró el registro actualizado de menu");

        return new ActivarInactivarMenuResponse(
            regActualizado.AplicacionId,
            regActualizado.ModuloId,
            regActualizado.MenuId,
            regActualizado.NombreMenu,
            regActualizado.EtiquetaMenu,
            regActualizado.DescMenu,
            regActualizado.Url,
            regActualizado.Orden,
            regActualizado.Consulta,
            regActualizado.Inserta,
            regActualizado.Actualiza,
            regActualizado.Elimina,
            regActualizado.Activa,
            regActualizado.Ejecuta,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

    public async Task<ConsultarMenuPorIdResponse> ConsultarMenuPorId(Guid menuId)
    {
        var result = await _menuRepositorioLectura
            .Query(m => m.MenuId == menuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), menuId);

        return new ConsultarMenuPorIdResponse(
            result.AplicacionId,
            result.ModuloId,
            result.MenuId,
            result.NombreMenu,
            result.EtiquetaMenu,
            result.DescMenu,
            result.Url,
            result.Orden,
            result.Consulta,
            result.Inserta,
            result.Actualiza,
            result.Elimina,
            result.Activa,
            result.Ejecuta,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<DataViewModel<ConsultarMenusResponse>> ConsultarMenus(GetEntityQuery query, Guid aplicacionId, Guid? moduloId)
    {
        try
        {
            var filtroEspecificacion = new MenuEspecificacion(aplicacionId, moduloId, query.TextoBusqueda);

            var result = await _menuRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
                .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

            DataViewModel<ConsultarMenusResponse> consulta = new(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

            consulta.Data = result.Items.Select(item => new ConsultarMenusResponse(
                item.AplicacionId,
                item.ModuloId,
                item.MenuId,
                item.NombreMenu,
                item.EtiquetaMenu,
                item.DescMenu,
                item.Url,
                item.Orden,
                item.Consulta,
                item.Inserta,
                item.Actualiza,
                item.Elimina,
                item.Activa,
                item.Ejecuta,
                item.Activo,
                item.CreaUsuario,
                item.CreaFecha,
                item.ModificaUsuario,
                item.ModificaFecha)).ToList();

            return consulta;
        }
        catch (Exception ex)
        {
            throw new BadRequestCustomException("No se logro cosultar los menús", ex);
        }
    }

    public async Task<IEnumerable<ConsultarMenusPorParametrosResponse>> ConsultarMenusPorParametros(Guid aplicacionId, Guid? moduloId, string filtro)
    {
        var filtroEspecificacion = new MenuEspecificacion(aplicacionId, moduloId, filtro);

        var result = await _menuRepositorioLectura
            .Query(filtroEspecificacion.Criteria.And(m => m.Modulo.Activo).And(m => m.Activo))
            .Include(p => p.Modulo.Apliation)
            .SelectAsync(m => new ConsultarMenusPorParametrosResponse(
                m.AplicacionId,
                m.ModuloId,
                m.MenuId,
                m.NombreMenu,
                m.EtiquetaMenu,
                m.DescMenu,
                m.Url,
                m.Orden,
                m.Modulo.NombreModulo,
                m.Modulo.Apliation.NombreAplicacion,
                m.Consulta,
                m.Inserta,
                m.Actualiza,
                m.Elimina,
                m.Activa,
                m.Ejecuta));

        return result;
    }

    public async Task<IEnumerable<ConsultarMenuUsuarioResponse>> ConsultarMenuUsuario()
    {
        var perfilMenus = await _perfilMenuRepositorioLectura
            .Query(q => q.Perfil.Activo && q.Menu.Modulo.Apliation.Activo && q.Menu.Modulo.Activo && q.Menu.Activo &&
                   q.Perfil.UsuarioPerfiles.FirstOrDefault(f => f.UsuarioId == ContextAccessor.UserId) != null)
            .Include(p => p.Menu.Modulo.Apliation)
            .SelectAsync();

        var permisosAplicaciones = perfilMenus
            .GroupBy(u => u.Menu.Modulo.Apliation)
            .OrderBy(o => o.Key.NombreAplicacion)
            .Select(aplication => new ConsultarMenuUsuarioResponse(
                aplication.Key.AplicacionId,
                aplication.Key.NombreAplicacion,
                aplication.Key.DescAplicacion,
                aplication.GroupBy(u => u.Menu.Modulo)
                .OrderBy(o => o.Key.Orden)
                .Select(modulo => new Module(
                    modulo.Key.ModuloId,
                    modulo.Key.NombreModulo,
                    modulo.Key.DescModulo,
                    modulo.Key.IconoPrefijo,
                    modulo.Key.IconoNombre,
                    modulo.GroupBy(g => g.Menu)
                    .OrderBy(o => o.Key.Orden)
                    .Select(menu => new ModuleOption(
                        menu.Key.MenuId,
                        menu.Key.NombreMenu,
                        menu.Key.EtiquetaMenu,
                        menu.Key.Url,
                        menu.Key.Orden,
                        menu.Max(m => m.Inserta) && menu.Key.Inserta,
                        menu.Max(m => m.Consulta) && menu.Key.Consulta,
                        menu.Max(m => m.Actualiza) && menu.Key.Actualiza,
                        menu.Max(m => m.Activa) && menu.Key.Activa,
                        menu.Max(m => m.Elimina) && menu.Key.Elimina,
                        menu.Max(m => m.Ejecuta) && menu.Key.Ejecuta,
                        menu.Key.Inserta,
                        menu.Key.Consulta,
                        menu.Key.Actualiza,
                        menu.Key.Activa,
                        menu.Key.Elimina,
                        menu.Key.Ejecuta))))));

        return permisosAplicaciones;
    }

    public async Task<CrearMenuResponse> CrearMenu(CrearMenuCommand registroDto)
    {
        var registro = new Menu
        {
            AplicacionId = registroDto.AplicacionId,
            ModuloId = registroDto.ModuloId,
            MenuId = Guid.NewGuid(),
            NombreMenu = registroDto.NombreMenu,
            EtiquetaMenu = registroDto.EtiquetaMenu,
            DescMenu = registroDto.DescMenu,
            Url = registroDto.Url,
            Orden = registroDto.Orden,
            Consulta = registroDto.Consulta,
            Inserta = registroDto.Inserta,
            Actualiza = registroDto.Actualiza,
            Elimina = registroDto.Elimina,
            Activa = registroDto.Activa,
            Ejecuta = registroDto.Ejecuta
        };

        _menuRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearMenuResponse(
            registro.AplicacionId,
            registro.ModuloId,
            registro.MenuId,
            registro.NombreMenu,
            registro.EtiquetaMenu,
            registro.DescMenu,
            registro.Url,
            registro.Orden,
            registro.Consulta,
            registro.Inserta,
            registro.Actualiza,
            registro.Elimina,
            registro.Activa,
            registro.Ejecuta);
    }

    public async Task<EditarMenuResponse> EditarMenu(EditarMenuCommand registroDto)
    {
        var regActualizar = await _menuRepositorioLectura
            .Query(m => m.MenuId == registroDto.MenuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), registroDto.MenuId);

        regActualizar.NombreMenu = registroDto.NombreMenu;
        regActualizar.EtiquetaMenu = registroDto.EtiquetaMenu;
        regActualizar.DescMenu = registroDto.DescMenu;
        regActualizar.Url = registroDto.Url;
        regActualizar.Orden = registroDto.Orden;
        regActualizar.Consulta = registroDto.Consulta;
        regActualizar.Inserta = registroDto.Inserta;
        regActualizar.Actualiza = registroDto.Actualiza;
        regActualizar.Elimina = registroDto.Elimina;
        regActualizar.Activa = registroDto.Activa;
        regActualizar.Ejecuta = registroDto.Ejecuta;

        _menuRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _menuRepositorioLectura
            .Query(m => m.MenuId == registroDto.MenuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("No se encontró el registro actualizado de menu");

        return new EditarMenuResponse(
            regActualizado.AplicacionId,
            regActualizado.ModuloId,
            regActualizado.MenuId,
            regActualizado.NombreMenu,
            regActualizado.EtiquetaMenu,
            regActualizado.DescMenu,
            regActualizado.Url,
            regActualizado.Orden,
            regActualizado.Consulta,
            regActualizado.Inserta,
            regActualizado.Actualiza,
            regActualizado.Elimina,
            regActualizado.Activa,
            regActualizado.Ejecuta,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}