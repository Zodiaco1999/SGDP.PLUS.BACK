using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.BuscadorTercero;

public record struct BuscadorTerceroCommand(string NitEmpresa, string NombreEmpresa = "") : IRequest<List<BuscadorTerceroResponse>>;