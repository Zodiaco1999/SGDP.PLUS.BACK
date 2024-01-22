﻿using LinqKit;
using Newtonsoft.Json;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft.DTO;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaftTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.Repositorio.IlicitosRespuestas;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.Repositorio.InfoBasicas;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.Repositorio.RespuestaLafts;
using SGDP.PLUS.INFOTERCERO.Dominio.DTO;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using System.Xml;
using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

public class GestionTerceros : BaseAppService, IGestionTerceros
{
    private readonly IInfoBasicaRepositorioLectura _infoBasicaLectura;
    private readonly IInfoBasicaRepositorioEscritura _infoBasicaEscritura;
    private readonly IRespuestaLaftRepositorioEscritura _respuestaLaftEscritura;
    private readonly IIlicitosRespuestaEscritura _ilicitosRespuestaEscritura;
    private readonly IUnitOfWorkInfoTerceroEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _http;
    private readonly string _sectionApi = "ApiSeiyaInformaDesarrollo";

    public GestionTerceros(
        IInfoBasicaRepositorioLectura infoBasicaLectura,
        IInfoBasicaRepositorioEscritura infoBasicaEscritura,
        IRespuestaLaftRepositorioEscritura respuestaLaftEscritura,
        IIlicitosRespuestaEscritura ilicitosRespuestaEscritura,
        IUnitOfWorkInfoTerceroEscritura unitOfWorkInfoTerceroEscritura,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory,
        IConfiguration configuration,
        HttpClient http
        ) : base(contextAccessor, loggerFactory)
    {
        _infoBasicaLectura = infoBasicaLectura;
        _infoBasicaEscritura = infoBasicaEscritura;
        _respuestaLaftEscritura = respuestaLaftEscritura;
        _ilicitosRespuestaEscritura = ilicitosRespuestaEscritura;
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

        informe.EmpresaSintesisInternacional.Resumen_Str = producto.InformeXml;

        var listaAdministradores = new List<AdministradorDto>();
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
        var repuestaLaft = JsonConvert.DeserializeObject<RepuestaLaft>(responseAsString) ?? new();

        repuestaLaft.LaftResponse.RespuestaJson = responseAsString;

        return repuestaLaft.LaftResponse;
    }

    public async Task<ConsultaLaftTerceroResponse> ConsultaLaftTercero(ConsultaLaftTerceroCommand command)
    {
        var informe = await ObtenerInforme(new ObtenerInformeCommand(command.Nit));
        var fechaSolicitud = DateTime.Now;

        TerceroSave(command.Nit, fechaSolicitud, informe);

        var numerosIndentificacion = new List<string> { command.Nit };
        numerosIndentificacion.AddRange(informe.Administradores.Select(a => a.Cedula).Where(a => !string.IsNullOrEmpty(a)));

        var identificaciones = numerosIndentificacion.Distinct();
        var resumenRespuesta = new ResumenRespuesta();
        var ilicitos = new List<ListaIlicitos>();
        
        await Parallel.ForEachAsync(identificaciones, async (identificacion, _) =>
        {
            var consultaLaft = await ConsultaLaft(new ConsultaLaftCommand(identificacion));
            SaveRespuestaLaft(consultaLaft, identificacion, fechaSolicitud, command.Nit);

            ilicitos.AddRange(consultaLaft.ListaIlicitos);
        });

        int numeroOcurrencias = ilicitos.Count;
        resumenRespuesta.NumeroOcurrencias = numeroOcurrencias.ToString();
        resumenRespuesta.Alerta = numeroOcurrencias > 0 ? "SI" : "NO";

        return new ConsultaLaftTerceroResponse() { ResumenRespuesta = resumenRespuesta, ListaIlicitos = ilicitos };
    }

    private void TerceroSave(string nit, DateTime fechaSolicitud, ObtenerInformeResponse informe)
    {
        var iBasica = informe.TerceroInfoBasica;

        var tercero = new InfoBasica
        {
            Nit = nit,
            FechaSolicitud = fechaSolicitud,
            Ici = iBasica.Ici,
            IdFiscal = iBasica.IdFiscal,
            FechaConstitucion = Convert.ToDateTime(iBasica.FechaConstitucion),
            Email = iBasica.Email,
            FormaJuridicaCod = iBasica.FormaJuridicaCod,
            Actividad = iBasica.Actividad,
            Denominacion = iBasica.Denominacion,
            Ciudad = iBasica.Ciudad,
            DomicilioSocial = iBasica.DomicilioSocial,
            Telefono = iBasica.Telefono,
            Informe_Str = iBasica.Resumen_Str,
            Administradors = informe.Administradores.Select(a => new Administrador
            {
                AdministradorId = Guid.NewGuid(),
                Cedula = a.Cedula,
                Nombre = a.Nombre,
                Cargo = a.Cargo,
                CodigoCargo = a.CodigoCargo,
                ConsultaVinculaciones = a.ConsultaVinculaciones,
                ConsultarVinculo = a.ConsultarVinculo,
                ConsultarNoDisponible = a.ConsultarNoDisponible,
                ConsultaLaft = a.ConsultaLaft,
                FechaNombramiento = a.FechaNombramiento,
                FechaCambioAdmin = a.FechaCambioAdm
            }).ToList()
        };

        _infoBasicaEscritura.Insert(tercero);
        _unitOfWork.SaveChanges();
    }

    private void SaveRespuestaLaft(ConsultaLaftResponse laftResponse, string identificacionConsultada, DateTime fechaSolicitud, string nit)
    {
        var respuestaLaft = new RespuestaLaft
        {
            RespuestaLaftId = Guid.NewGuid(),
            CodigoInforma = laftResponse.ResumenRespuesta.CodigoInforma,
            IdentificacionConsultada = identificacionConsultada,
            FechaSolicitud = fechaSolicitud,
            NitTerceroAplica = nit,
            Alertado = laftResponse.ResumenRespuesta.Alerta.Trim() == "SI",
            IdUsuarioSolicitud = _contextAccessor.UserId ?? "N/A",
            RespuestaJson = laftResponse.RespuestaJson
        };

        _respuestaLaftEscritura.Insert(respuestaLaft);
        _unitOfWork.SaveChanges();

        laftResponse.ListaIlicitos.ForEach(i =>
        {
            var ilicto = new IlicitosRespuesta
            {
                RespuestaLaftId = respuestaLaft.RespuestaLaftId,
                NumReg = i.NumReg,
                PorcentajeCoincidencia = i.PorcentajeDeCoincidencia,
                Coincidencia = i.Coincidencia,
                ConsultaRealizada = i.ConsultaRealizada,
                Lista = i.Lista,
                NombreEncontrado = i.NombreEncontrado,
                IdentificacionEncontrada = i.IdentificacionEncontrada,
                DelitoOcausa = i.DelitoOCausa,
                Alias = string.IsNullOrEmpty(i.Alias) ? null : i.Alias,
                Fuente = i.Fuente,
                FechaCarga = string.IsNullOrEmpty(i.FechaCarga) ? null : i.FechaCarga,
                Ciudad = i.Ciudad,
                FechaPublicacion = string.IsNullOrEmpty(i.FechaPublicacion) ? null : i.FechaPublicacion,
                Demandante = i.Demandante,
                Detalle = i.Detalle
            };
            _ilicitosRespuestaEscritura.Insert(ilicto);
            _unitOfWork.SaveChanges();
        });
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