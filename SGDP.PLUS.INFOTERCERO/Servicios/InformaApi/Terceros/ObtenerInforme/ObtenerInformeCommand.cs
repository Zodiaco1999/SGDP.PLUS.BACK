using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ObtenerInforme;

public record struct ObtenerInformeCommand(string Nit) : IRequest<ObtenerInformeResponse>;

public record struct ObtenerInformeRequest(
    string Ici,
    string Nit,
    string CodigoProducto,
    Informe InformeJson,
    Informe InformePdf,
    Informe InformeXml);

public record struct Informe(bool Habilitar, bool CodificarBase64 = false);