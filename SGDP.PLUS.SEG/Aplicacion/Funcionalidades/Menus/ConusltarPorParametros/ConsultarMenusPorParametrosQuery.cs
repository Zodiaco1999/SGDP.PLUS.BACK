using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;

public record struct ConsultarMenusPorParametrosQuery(
    Guid AplicacionId,
    Guid? ModuloId,
    string TextoBusqueda) : IRequest<IEnumerable<ConsultarMenusPorParametrosResponse>>;
