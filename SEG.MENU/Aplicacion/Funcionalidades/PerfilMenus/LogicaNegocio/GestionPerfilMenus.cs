using Ardalis.GuardClauses;
using SEG.Comun.ContextAccesor;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

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

    public async Task<DataViewModel<ConsultarPerfilMenusResponse>> ConsultarPerfilMenus(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PerfilMenuEspecificacion(filtro);

            DataViewModel<ConsultarPerfilMenusResponse> consulta = new DataViewModel<ConsultarPerfilMenusResponse>();

            var result = await _perfilMenuRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            consulta.TotalRecords = result.TotalItems;
            consulta.Data = new List<ConsultarPerfilMenusResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarPerfilMenusResponse(
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
                                item.ModificaFecha
                                );
                consulta.Data.Add(det);
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(PerfilMenu), ex.Message);
        }
    }

    public async Task<CrearPerfilMenusResponse> CrearPerfilMenu(CrearPerfilMenusCommand registroDto)
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

        return new CrearPerfilMenusResponse(
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

    public async Task<ConsultarPerfilMenuPorIdResponse> ConsultarPerfilMenu(Guid perfilId)
    {
        var result = await _perfilMenuRepositorioLectura
            .Query(p => p.PerfilId == perfilId)
            .FirstOrDefaultAsync();

        return new ConsultarPerfilMenuPorIdResponse(
            result.PerfilId,
            result.AplicacionId,
            result.ModuloId,
            result.MenuId,
            result.Consulta,
            result.Inserta,
            result.Actualiza,
            result.Elimina,
            result.Activa,
            result.Ejecuta,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }

    public async Task<EditarPerfilMenusResponse> ActualizarPerfilMenu(EditarPerfilMenusCommand registroDto)
    {
        var regActualizar = await _perfilMenuRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(PerfilMenu), "No se encontró el registro a actualizar");
        }

        regActualizar.PerfilId = registroDto.PerfilId;
        regActualizar.AplicacionId = registroDto.AplicacionId;
        regActualizar.ModuloId = registroDto.ModuloId;
        regActualizar.MenuId = registroDto.MenuId;
        regActualizar.Consulta = registroDto.Consulta;
        regActualizar.Inserta = registroDto.Inserta;
        regActualizar.Actualiza = registroDto.Actualiza;
        regActualizar.Elimina = registroDto.Elimina;
        regActualizar.Activa = registroDto.Activa;
        regActualizar.Ejecuta = registroDto.Ejecuta;

        _perfilMenuRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _perfilMenuRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(PerfilMenu), "No se encontró el registro a actualizado");
        }

        return new EditarPerfilMenusResponse(
            regActualizado.PerfilId,
            regActualizado.AplicacionId,
            regActualizado.ModuloId,
            regActualizado.MenuId,
            regActualizado.Consulta,
            regActualizado.Inserta,
            regActualizado.Actualiza,
            regActualizado.Elimina,
            regActualizado.Activa,
            regActualizado.Ejecuta,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}
