using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaftTercero;

public record struct ConsultaLaftTerceroCommand(string Nit) : IRequest<ConsultaLaftTerceroResponse>;
