using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaftTercero;

public record struct ConsultaLaftTerceroCommand(string Nit) : IRequest<ConsultaLaftTerceroResponse>;
