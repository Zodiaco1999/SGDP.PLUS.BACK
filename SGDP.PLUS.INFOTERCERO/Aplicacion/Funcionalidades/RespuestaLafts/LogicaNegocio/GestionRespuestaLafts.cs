using Azure;
using MediatR;
using NetTopologySuite.Index.HPRtree;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.InfoBasicas.Repositorio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Consultar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Repositorio;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaftTercero;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;
using System.Linq.Expressions;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

public class GestionRespuestaLafts : BaseAppService, IGestionRespuestaLafts
{
    private readonly IRespuestaLaftRepositorioLectura _respuestaLaftLectura;
    private readonly IInfoBasicaRepositorioLectura _infoBasicaLectura;
    private readonly IGestionInformaApi _gestionInformaApi;

    public GestionRespuestaLafts(
        IRespuestaLaftRepositorioLectura respuestaLaftLectura,
        IInfoBasicaRepositorioLectura infoBasicaLectura,
        IGestionInformaApi gestionInformaApi,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _respuestaLaftLectura = respuestaLaftLectura;
        _infoBasicaLectura = infoBasicaLectura;
        _gestionInformaApi = gestionInformaApi;
    }

    public async Task<IEnumerable<ConsultarDetalleLaftResponse>> ConsultarDetalleLaft(ConsultarDetalleLaftQuery query)
    {
        var result = await _infoBasicaLectura
            .Query(r => r.Nit == query.Nit && r.FechaSolicitud == query.FechaSolicitud)
            .Include(r => r.Administradors)
            .Include(r => r.RespuestaLafts)
            .FirstOrDefaultAsync();

        var response = new List<ConsultarDetalleLaftResponse>();

        var respuestasLaft = result.RespuestaLafts.Where(r => r.Alertado);

        foreach (var respuesta in respuestasLaft)
        {
            var administrador = result.Administradors.FirstOrDefault(a => a.Cedula == respuesta.IdentificacionConsultada);

            response.Add(new ConsultarDetalleLaftResponse(
                respuesta.RespuestaLaftId,
                respuesta.IdentificacionConsultada,
                respuesta.InfoBasica.Nit == respuesta.IdentificacionConsultada ? respuesta.InfoBasica.Denominacion : administrador?.Nombre ?? "",
                administrador?.CodigoCargo ?? "",
                administrador?.Cargo ?? "",
                !string.IsNullOrEmpty(administrador?.FechaNombramiento) ? Convert.ToDateTime(administrador.FechaNombramiento) : null,
                !string.IsNullOrEmpty(administrador?.FechaCambioAdmin) ? Convert.ToDateTime(administrador.FechaCambioAdmin) : null));
        }

        return response;
    }

    public async Task<DataViewModel<ConsultarRespuestaLaftPorNitResponse>> ConsultarRespuestaLaftPorNit(ConsultarRespuestaLaftPorNitQuery query)
    {
        Expression<Func<RespuestaLaft, bool>> filter = r => r.NitTerceroAplica == query.Nit && r.IdentificacionConsultada == query.Nit;

        var respuestaLaft = _respuestaLaftLectura.Queryable().Any(filter);
        if (!respuestaLaft || query.Actualiza)
        {
            await _gestionInformaApi.ConsultaLaftTercero(new ConsultaLaftTerceroCommand(query.Nit));
        }

        var result = await _respuestaLaftLectura
            .Query(filter)
            .OrderBy("FechaSolicitud", false)
            .Include(r => r.InfoBasica)
            .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

        var dataViemModel = new DataViewModel<ConsultarRespuestaLaftPorNitResponse>(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

        dataViemModel.Data = result.Items.Select(item => new ConsultarRespuestaLaftPorNitResponse(
            item.CodigoInforma,
            item.NitTerceroAplica,
            item.InfoBasica.Denominacion,
            item.FechaSolicitud,
            _respuestaLaftLectura
                .Queryable()
                .Any(r => r.NitTerceroAplica == item.NitTerceroAplica && r.FechaSolicitud == item.FechaSolicitud && r.Alertado)
            )).ToList();

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