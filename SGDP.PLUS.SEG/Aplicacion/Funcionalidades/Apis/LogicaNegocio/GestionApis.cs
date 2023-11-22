using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

public class GestionApis : BaseAppService, IGestionApis
{
    private readonly IApiRepositorioLectura _apiRepositorioLectura;
    private readonly IApiRepositorioEscritura _apiRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionApis(
        IApiRepositorioLectura apiRepositorioLectura,
        IApiRepositorioEscritura apiRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _apiRepositorioLectura = apiRepositorioLectura;
        _apiRepositorioEscritura = apiRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task ActivarInactivarApi(Guid apiId)
    {
        var regActualizar = await _apiRepositorioLectura
            .Query(x => x.ApiId == apiId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Api), apiId);

        regActualizar.Activo = !regActualizar.Activo;

        _apiRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<ConsultarApisResponse>> ConsultarApis(Guid aplicacionId)
    {
        return await _apiRepositorioLectura
            .Query(a => a.AplicacionId == aplicacionId)
            .SelectAsync(a => new ConsultarApisResponse(
                a.AplicacionId,
                a.ApiId,
                a.NombreApi,
                a.DescripcionApi,
                a.UrlPrueba,
                a.UrlProduccion,
                a.Activo)) ?? new List<ConsultarApisResponse>();
    }

    public async Task<CrearApiResponse> CrearApi(CrearApiCommand registroDto)
    {
        var registro = new Api
        {
            AplicacionId = registroDto.AplicacionId,
            ApiId = Guid.NewGuid(),
            NombreApi = registroDto.NombreApi,
            DescripcionApi = registroDto.DescripcionApi,
            UrlPrueba = registroDto.UrlPrueba,
            UrlProduccion = registroDto.UrlProduccion
        };

        _apiRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearApiResponse(
            registro.AplicacionId,
            registro.ApiId,
            registro.NombreApi,
            registro.DescripcionApi,
            registro.UrlPrueba,
            registro.UrlProduccion,
            registro.Activo);
    }

    public async Task EditarApi(EditarApiCommand registroDto)
    {
        var regActualizar = await _apiRepositorioLectura
            .Query(x => x.ApiId == registroDto.ApiId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Api), registroDto.ApiId);

        regActualizar.NombreApi = registroDto.NombreApi;
        regActualizar.DescripcionApi = registroDto.DescripcionApi;
        regActualizar.UrlPrueba = registroDto.UrlPrueba;
        regActualizar.UrlProduccion = registroDto.UrlProduccion;

        _apiRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();
    }
}