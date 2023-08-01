using Ardalis.GuardClauses;
using LinqKit;
using NetTopologySuite.Index.HPRtree;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

public class GestionMenus : BaseAppService, IGestionMenus
{
    private readonly IMenuRepositorioLectura _menuRepositorioLectura;
    private readonly IMenuRepositorioEscritura _menuRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionMenus(
        IMenuRepositorioLectura menuRepositorioLectura,
        IMenuRepositorioEscritura menuRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _menuRepositorioLectura = menuRepositorioLectura;
        _menuRepositorioEscritura = menuRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarMenuResponse> ActivarInactivarMenu(Guid menuId)
    {
        var regActualizar = await _menuRepositorioLectura
            .Query(m => m.MenuId == menuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), "No se encontró el registro a actualizar");

        regActualizar.Activo = !regActualizar.Activo;

        _menuRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _menuRepositorioLectura
            .Query(m => m.MenuId == menuId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), "No se encontró el registro actualizado");

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
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), "No se encontró el registro");

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

    public async Task<DataViewModel<ConsultarMenusResponse>> ConsultarMenus(Guid aplicacionId, Guid? moduloId, string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new MenuEspecificacion(aplicacionId, moduloId, filtro);

            var result = await _menuRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina); 

            DataViewModel<ConsultarMenusResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarMenusResponse>();

            foreach (var item in result.Items!)
            {
                consulta.Data.Add(new ConsultarMenusResponse(
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
                                 item.ModificaFecha));
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Menu), ex.Message);
        }
    }

    public async Task<IEnumerable<ConsultarMenusPorParametrosResponse>> ConsultarMenusPorParametros(Guid aplicacionId, Guid? moduloId, string filtro)
    {
        var filtroEspecificacion = new MenuEspecificacion(aplicacionId, moduloId, filtro);

        var result = await _menuRepositorioLectura
            .Query(filtroEspecificacion.Criteria.And(m => m.Activo))
            .SelectAsync();

        IEnumerable<ConsultarMenusPorParametrosResponse> menus = result.Select(m =>
        new ConsultarMenusPorParametrosResponse(
            m.AplicacionId,
            m.ModuloId,
            m.MenuId,
            m.NombreMenu,
            m.EtiquetaMenu,
            m.DescMenu,
            m.Url,
            m.Orden,
            m.Consulta,
            m.Inserta,
            m.Actualiza,
            m.Elimina,
            m.Activa,
            m.Ejecuta));

        return menus;
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
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), "No se encontró el registro");

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
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Menu), "No se encontró el registro actualizado");

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