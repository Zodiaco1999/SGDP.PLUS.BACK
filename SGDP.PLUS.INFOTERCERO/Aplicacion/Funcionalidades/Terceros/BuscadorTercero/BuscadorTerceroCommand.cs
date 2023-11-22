using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;

public record struct BuscadorTerceroCommand(string NitEmpresa, string NombreEmpresa = "") : IRequest<List<BuscadorTerceroResponse>>;