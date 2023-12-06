using Azure;
using Newtonsoft.Json;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft.DTO;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;
using SGDP.PLUS.INFOTERCERO.Dominio.DTO;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using System.Xml;
using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

public class GestionTerceros : BaseAppService, IGestionTerceros
{
    private readonly IUnitOfWorkInfoTerceroEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _http;
    private readonly string _sectionApi = "ApiSeiyaInformaProduccion";

    public GestionTerceros(
        IUnitOfWorkInfoTerceroEscritura unitOfWorkInfoTerceroEscritura,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory,
        IConfiguration configuration,
        HttpClient http
        ) : base(contextAccessor, loggerFactory)
    {
        _unitOfWork = unitOfWorkInfoTerceroEscritura;
        _contextAccessor = contextAccessor;
        _configuration = configuration;
        _http = http;
        var credentials = _configuration.GetSection("ifcColCredentials").Get<IfcColCredentials>() ?? new();
        _http.DefaultRequestHeaders.Add(credentials.Name, credentials.Value);
    }

    public async Task<List<BuscadorTerceroResponse>> BuscadorTercero(BuscadorTerceroCommand command)
    {
        string urlBuscador = _configuration.GetValue<string>($"{_sectionApi}:serviceBuscador")!;
        var response = await _http.PostAsJsonAsync(urlBuscador, command);

        await HandlerResponse(response);

        var buscadorResponse = await response.Content.ReadFromJsonAsync<List<BuscadorTerceroResponse>>() ?? new();

        return buscadorResponse;
    }

    public async Task<ObtenerInformeResponse> ObtenerInforme(ObtenerInformeCommand command)
    {
        var tercerosResponse = await BuscadorTercero(new BuscadorTerceroCommand(command.Nit));

        var tercero = tercerosResponse.FirstOrDefault();

        var request = new ObtenerInformeRequest(
            tercero.Ici,
            command.Nit,
            "IA-01",
            new Informe(),
            new Informe(),
            new Informe(true));

        string urlObtenerProducto = _configuration.GetValue<string>($"{_sectionApi}:serviceObtenerProducto")!;
        var response = await _http.PostAsJsonAsync(urlObtenerProducto, request);

        await HandlerResponse(response);

        var producto = await response.Content.ReadFromJsonAsync<ObtenerProducto>() ?? new();

        var serializer = new XmlSerializer(typeof(InformeAbreviadoInternacional));
        var informe = (InformeAbreviadoInternacional)serializer.Deserialize(new XmlTextReader(new StringReader(producto.InformeXml)))! ?? new();

        var listaAdministradores = new List<Administrador>();
        var admins = informe.AdministradoresPrincipalesInternacional.ListaAdministradores;

        var arrAdmins = new List<Admin> { admins.AdminConsejo, admins.AdminFirma, admins.AdminAuditor, admins.AdminFuncion };

        foreach (var admin in arrAdmins)
        {
            if (admin != null && admin.Administradores.Count > 0)
                listaAdministradores.AddRange(admin.Administradores);
        }
        
        return new ObtenerInformeResponse(informe.EmpresaSintesisInternacional, listaAdministradores.Count, listaAdministradores);
    }

    public async Task<ConsultaLaftResponse> ConsultaLaft(ConsultaLaftCommand command)
    {
        string urlConsultaLaft = _configuration.GetValue<string>($"{_sectionApi}:serviceConsultaLaft")!;
        var response = await _http.PostAsJsonAsync(urlConsultaLaft, command);

        await HandlerResponse(response);

        var responseAsString = await response.Content.ReadAsStringAsync();
        var laftResponse = JsonConvert.DeserializeObject<RepuestaLaft>(responseAsString) ?? new();

        return laftResponse.LaftResponse;
    }

    private async Task HandlerResponse(HttpResponseMessage response) 
    {
        if (!response.IsSuccessStatusCode)
        {
            var readBadRequest = await response.Content.ReadFromJsonAsync<BadResponseIfcCol>();
            throw new BadRequestCustomException(readBadRequest.MessageText, readBadRequest.ToString());
        }
    }

}