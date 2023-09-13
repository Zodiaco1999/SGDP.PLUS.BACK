using Ardalis.GuardClauses;
using LinqKit;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

public class GestionPerfilMenus : BaseAppService, IGestionPerfilMenus
{
    private readonly IPerfilMenuRepositorioLectura _perfilMenuRepositorioLectura;
    private readonly IPerfilMenuRepositorioEscritura _perfilMenuRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionPerfilMenus(
        IPerfilMenuRepositorioLectura perfilMenuRepositorioLectura,
        IPerfilMenuRepositorioEscritura perfilMenuRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _perfilMenuRepositorioLectura = perfilMenuRepositorioLectura;
        _perfilMenuRepositorioEscritura = perfilMenuRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<IEnumerable<ConsultarPerfilesPorAplicacionResponse>> ConsultarPerfilesPorAplicacion(Guid aplicacionId)
    {
       
        var result = await _perfilMenuRepositorioLectura
            .Query(p => p.AplicacionId == aplicacionId)
            .SelectAsync(p => new ConsultarPerfilesPorAplicacionResponse(
                p.AplicacionId,
                p.PerfilId,
                p.Menu.Modulo.Apliation.NombreAplicacion,
                p.Perfil.NombrePerfil));

        return result.DistinctBy(p => p.PerfilId);
    }

    public async Task<DataViewModel<ConsultarPerfilMenusResponse>> ConsultarPerfilMenus(Guid perfilId, Guid? aplicaionId, Guid? moduloId, string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PerfilMenuEspecificacion(perfilId, aplicaionId, moduloId, filtro);

            var result = await _perfilMenuRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .Include("Menu.Modulo.Apliation")
                .OrderBy(pm => pm.OrderBy(a => a.AplicacionId))
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarPerfilMenusResponse> consulta = new DataViewModel<ConsultarPerfilMenusResponse>(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarPerfilMenusResponse>();

            foreach (var item in result.Items!)
            {
                consulta.Data.Add(new ConsultarPerfilMenusResponse(
                                item.PerfilId,
                                item.AplicacionId,
                                item.ModuloId,
                                item.MenuId,
                                item.Consulta,
                                item.Inserta,
                                item.Actualiza,
                                item.Elimina,
                                item.Activa,
                                item.Ejecuta,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha,
                                item.Menu.Modulo.Apliation.NombreAplicacion,
                                item.Menu.Modulo.NombreModulo,
                                item.Menu.NombreMenu,
                                item.Menu.DescMenu));
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(PerfilMenu), ex.Message);
        }
    }

    public async Task<CrearPerfilMenuResponse> CrearPerfilMenu(CrearPerfilMenuCommand registroDto)
    {
        var registro = new PerfilMenu()
        {
            PerfilId = registroDto.PerfilId,
            AplicacionId = registroDto.AplicacionId,
            ModuloId = registroDto.ModuloId,
            MenuId = registroDto.MenuId,
            Consulta = registroDto.Consulta,
            Inserta = registroDto.Inserta,
            Actualiza = registroDto.Actualiza,
            Elimina = registroDto.Elimina,
            Activa = registroDto.Activa,
            Ejecuta = registroDto.Ejecuta
        };

        _perfilMenuRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearPerfilMenuResponse(
            registro.PerfilId,
            registro.AplicacionId,
            registro.ModuloId,
            registro.MenuId,
            registro.Consulta,
            registro.Inserta,
            registro.Actualiza,
            registro.Elimina,
            registro.Activa,
            registro.Ejecuta);
    }

    public async Task<IEnumerable<ConsultarPerfilMenusPorIdResponse>> ConsultarPerfilMenuPorId(Guid perfilId)
    {
        return await _perfilMenuRepositorioLectura
            .Query(p => p.PerfilId == perfilId)
            .SelectAsync(pm => new ConsultarPerfilMenusPorIdResponse(
                pm.PerfilId,
                pm.AplicacionId,
                pm.ModuloId,
                pm.MenuId,
                pm.Menu.NombreMenu,
                pm.Menu.DescMenu,
                pm.Menu.Modulo.NombreModulo,
                pm.Menu.Modulo.Apliation.NombreAplicacion,
                pm.Consulta,
                pm.Inserta,
                pm.Actualiza,
                pm.Elimina,
                pm.Activa,
                pm.Ejecuta,
                pm.Menu.Consulta,
                pm.Menu.Inserta,
                pm.Menu.Actualiza,
                pm.Menu.Elimina,
                pm.Menu.Activa,
                pm.Menu.Ejecuta,
                true));         
    }
  
    public async Task EditarPerfilMenu(List<EditarPerfilMenuCommand> perfilMenusDto, Guid perfilId)
    {
        var perfilMenusActualizar = await _perfilMenuRepositorioEscritura
            .Query(x => x.PerfilId == perfilId)
            .SelectAsync();

        var perfilMenusActuales = perfilMenusDto
            .Select(m => new PerfilMenu
            {
                PerfilId = perfilId,
                AplicacionId = m.AplicacionId,
                ModuloId = m.ModuloId,
                MenuId = m.MenuId,
                Consulta = m.Consulta,
                Inserta = m.Inserta,
                Actualiza = m.Actualiza,
                Elimina = m.Elimina,
                Activa = m.Activa,
                Ejecuta = m.Ejecuta
            });

        var menusActuales = perfilMenusActuales.Intersect(perfilMenusActualizar, new PerfilMenuEqualityComparer()).ToList();
        var menusAgregar = perfilMenusActuales.Except(perfilMenusActualizar, new PerfilMenuEqualityComparer()).ToList();
        var menusEliminar = perfilMenusActualizar.Except(perfilMenusActuales, new PerfilMenuEqualityComparer()).ToList();

        // Actualizar elementos
        foreach (var menuActual in menusActuales)
        {
            var menuActualizar = perfilMenusActualizar.FirstOrDefault(pm => pm.MenuId == menuActual.MenuId);
            if (menuActualizar != null)
            {
                menuActualizar.Consulta = menuActual.Consulta;
                menuActualizar.Inserta = menuActual.Inserta;
                menuActualizar.Actualiza = menuActual.Actualiza;
                menuActualizar.Elimina = menuActual.Elimina;
                menuActualizar.Activa = menuActual.Activa;
                menuActualizar.Ejecuta = menuActual.Ejecuta;

                _perfilMenuRepositorioEscritura.Update(menuActualizar);
            }
        }
        // Agregar elementos
        if (menusAgregar.Count > 0)
        {
            _perfilMenuRepositorioEscritura.InsertRange(menusAgregar);
        }
        // Eliminar elementos
        foreach (var menuEliminar in menusEliminar)
        {
            await _perfilMenuRepositorioEscritura.DeleteAsync(menuEliminar.PerfilId, menuEliminar.MenuId);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public class PerfilMenuEqualityComparer : IEqualityComparer<PerfilMenu>
    {
        public bool Equals(PerfilMenu x, PerfilMenu y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return x.PerfilId == y.PerfilId &&
                   x.AplicacionId == y.AplicacionId &&
                   x.ModuloId == y.ModuloId &&
                   x.MenuId == y.MenuId;
        }

        public int GetHashCode(PerfilMenu obj)
        {
            unchecked
            {
                int hashCode = obj.PerfilId.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.AplicacionId.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.ModuloId.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.MenuId.GetHashCode();
                return hashCode;
            }
        }
    }
}
