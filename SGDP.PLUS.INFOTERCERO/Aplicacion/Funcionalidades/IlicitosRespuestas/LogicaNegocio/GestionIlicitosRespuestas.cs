using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Consultar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Repositorio;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.LogicaNegocio;

public class GestionIlicitosRespuestas : BaseAppService, IGestionIlicitosRespuestas
{
    private readonly IIlicitosRespuestaLectura _ilicitosrespuestaLectura;

    public GestionIlicitosRespuestas(
        IIlicitosRespuestaLectura ilicitosrespuestaRepositorioLectura,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _ilicitosrespuestaLectura = ilicitosrespuestaRepositorioLectura;
    }

    public async Task<DataViewModel<ConsultarIlicitosRespuestasResponse>> ConsultarIlicitosRespuestas(ConsultarIlicitosRespuestasQuery query)
    {
        var result = await _ilicitosrespuestaLectura
           .Query(i => i.RespuestaLaft.NitTerceroAplica == query.Nit && i.RespuestaLaft.FechaSolicitud == query.FechaSolicitud)
           .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
           .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

        var dataViemModel = new DataViewModel<ConsultarIlicitosRespuestasResponse>(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

        dataViemModel.Data = result.Items.Select(item => new ConsultarIlicitosRespuestasResponse(
            item.RespuestaLaftId,
            item.Coincidencia,
            item.PorcentajeCoincidencia,
            item.ConsultaRealizada,
            item.NombreEncontrado,
            item.IdentificacionEncontrada,
            item.Lista,
            item.DelitoOcausa,
            item.Alias,
            item.Fuente,
            item.FechaCarga,
            item.Ciudad,
            item.FechaPublicacion,
            item.Demandante,
            item.Detalle)).ToList();

        return dataViemModel;
    }

    public async Task<DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>> ConsultarIlicitosRespuestaPorId(ConsultarIlicitosRespuestaPorIdQuery query)
    {
        var result = await _ilicitosrespuestaLectura
            .Query(i => i.RespuestaLaftId == query.RespuestaLaftId)
            .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
            .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

        var dataViemModel = new DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

        dataViemModel.Data = result.Items.Select(item => new ConsultarIlicitosRespuestaPorIdResponse(
            item.RespuestaLaftId,
            item.Coincidencia,
            item.PorcentajeCoincidencia,
            item.ConsultaRealizada,
            item.NombreEncontrado,
            item.IdentificacionEncontrada,
            item.Lista,
            item.DelitoOcausa,
            item.Alias,
            item.Fuente,
            item.FechaCarga,
            item.Ciudad,
            item.FechaPublicacion,
            item.Demandante,
            item.Detalle)).ToList();

        return dataViemModel;
    }
}