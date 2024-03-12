using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaftTercero;

public record struct ConsultaLaftTerceroCommand(string Nit) : IRequest<ConsultaLaftTerceroResponse>;
