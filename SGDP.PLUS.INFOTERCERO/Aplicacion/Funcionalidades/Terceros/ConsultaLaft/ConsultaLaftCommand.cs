using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;

public record struct ConsultaLaftCommand(
    string Identificacion,
    string Nombre = "",
    string Monitoreo = "N") : IRequest<ConsultaLaftResponse>;
