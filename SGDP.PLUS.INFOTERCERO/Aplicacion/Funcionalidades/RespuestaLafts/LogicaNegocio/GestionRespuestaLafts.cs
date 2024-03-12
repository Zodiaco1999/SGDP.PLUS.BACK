using Azure;
using MediatR;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.InfoBasicas.Repositorio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Consultar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Repositorio;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

public class GestionRespuestaLafts : BaseAppService, IGestionRespuestaLafts
{
    private readonly IRespuestaLaftRepositorioLectura _respuestaLaftLectura;
    private readonly IRespuestaLaftRepositorioEscritura _respuestaLaftEscritura;
    private readonly IInfoBasicaRepositorioLectura _infoBasicaLectura;
    private readonly IUnitOfWorkInfoTerceroEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionRespuestaLafts(
        IRespuestaLaftRepositorioLectura respuestaLaftLectura,
        IRespuestaLaftRepositorioEscritura respuestaLaftEscritura,
        IInfoBasicaRepositorioLectura infoBasicaLectura,
        IUnitOfWorkInfoTerceroEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _respuestaLaftLectura = respuestaLaftLectura;
        _respuestaLaftEscritura = respuestaLaftEscritura;
        _infoBasicaLectura = infoBasicaLectura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<IEnumerable<ConsultarDetalleLaftResponse>> ConsultarDetalleLaft(ConsultarDetalleLaftQuery query)
    {
        var result = await _infoBasicaLectura
            .Query(r => r.Nit == query.Nit && r.FechaSolicitud == query.FechaSolicitud)
            .Include(r => r.Administradors)
            .Include(r => r.RespuestaLafts)
            .FirstOrDefaultAsync();

        var response = new List<ConsultarDetalleLaftResponse>();

        foreach (var respuesta in result.RespuestaLafts)
        {
            var administrador = result.Administradors.FirstOrDefault(a => a.Cedula == respuesta.IdentificacionConsultada);

            response.Add(new ConsultarDetalleLaftResponse(
                respuesta.IdentificacionConsultada,
                administrador?.Nombre ?? "",
                administrador?.CodigoCargo ?? "",
                administrador?.Cargo ?? "",
                respuesta.Alertado,
                !string.IsNullOrEmpty(administrador?.FechaNombramiento) ? Convert.ToDateTime(administrador.FechaNombramiento) : null,
                !string.IsNullOrEmpty(administrador?.FechaCambioAdmin) ? Convert.ToDateTime(administrador.FechaCambioAdmin) : null));
        }

        return response;
    }

    public async Task<DataViewModel<ConsultarRespuestaLaftPorNitResponse>> ConsultarRespuestaLaftPorNit(string nit, int pagina, int registrosPorPagina)
    {
        var result = await _respuestaLaftLectura
            .Query(r => r.NitTerceroAplica == nit && r.IdentificacionConsultada == nit)
            .OrderBy("FechaSolicitud", false)
            .Include(r => r.InfoBasica)
            .SelectPageAsync(pagina, registrosPorPagina);

        if (result.TotalItems == 0)
        {

        }

        var dataViemModel = new DataViewModel<ConsultarRespuestaLaftPorNitResponse>(pagina, registrosPorPagina, result.TotalItems);

        dataViemModel.Data = result.Items.Select(item => new ConsultarRespuestaLaftPorNitResponse(
            item.CodigoInforma,
            item.NitTerceroAplica,
            item.InfoBasica.Denominacion,
            item.FechaSolicitud,
            item.Alertado)).ToList();

        var item = result.Items.FirstOrDefault();

        await ConsultarDetalleLaft(new ConsultarDetalleLaftQuery(item.NitTerceroAplica, item.FechaSolicitud));

        return dataViemModel;
    }

    public Task<DataViewModel<ConsultarRespuestaLaftsResponse>> ConsultarRespuestaLafts(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        throw new NotImplementedException();
    }

    public Task<CrearRespuestaLaftResponse> CrearRespuestaLaft(CrearRespuestaLaftCommand registroDto)
    {
        throw new NotImplementedException();
    }

    public Task<EditarRespuestaLaftResponse> EditarRespuestaLaft(EditarRespuestaLaftCommand registroDto)
    {
        throw new NotImplementedException();
    }
}