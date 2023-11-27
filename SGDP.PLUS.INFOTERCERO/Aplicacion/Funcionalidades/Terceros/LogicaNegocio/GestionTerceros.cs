﻿using Newtonsoft.Json;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;
using SGDP.PLUS.INFOTERCERO.Dominio.DTO;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

public class GestionTerceros : BaseAppService, IGestionTerceros
{
    private readonly IUnitOfWorkInfoTerceroEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _http;
    private readonly string _sectionApi = "ApiSeiyaInforma";

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

        if (!response.IsSuccessStatusCode)
        {
            var readBadRequest = await response.Content.ReadFromJsonAsync<BadResponseIfcCol>();
            throw new BadRequestCustomException(readBadRequest.MessageText, readBadRequest.ToString());
        }

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
            new Informe(true),
            new Informe(),
            new Informe());

        string urlObtenerProducto = _configuration.GetValue<string>($"{_sectionApi}:serviceObtenerProducto")!;
        var response = await _http.PostAsJsonAsync(urlObtenerProducto, request);

        if (!response.IsSuccessStatusCode)
        {
            var readBadRequest = await response.Content.ReadAsStringAsync();
            throw new ValidationException(readBadRequest);
        }

        var responseAsString = await response.Content.ReadAsStringAsync();
        var informe = JsonConvert.DeserializeObject<InformeAbreviado>(responseAsString) ?? new InformeAbreviado();

        var listaAdministradores = new List<Administrador>();
        var admins = informe.InformeJson.AdministradoresPrincipalesInternacional.ListaAdministradores;

        if (admins != null)
        {
            var adminConsejo = admins.AdminConsejo;
            var adminFirma = admins.AdminFirma;
            var adminAuditores = admins.AdminAuditor;
            var adminFuncion = admins.AdminFuncion;

            if (adminConsejo != null && adminConsejo.Administradores.Count > 0)
                listaAdministradores.AddRange(adminConsejo.Administradores);

            if (adminFirma != null && adminFirma.Administradores.Count > 0)
                listaAdministradores.AddRange(adminFirma.Administradores);

            if (adminAuditores != null && adminAuditores.Administradores.Count > 0)
                listaAdministradores.AddRange(adminAuditores.Administradores);

            if (adminFuncion != null && adminFuncion.Administradores.Count > 0)
                listaAdministradores.AddRange(adminFuncion.Administradores);
        }

        return new ObtenerInformeResponse(informe.InformeJson.EmpresaSintesisInternacional, listaAdministradores);
    }
}