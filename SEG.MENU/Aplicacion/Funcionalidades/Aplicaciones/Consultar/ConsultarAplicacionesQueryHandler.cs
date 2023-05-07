using MediatR;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Interfaces;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public class ConsultarAplicacionesQueryHandler : IRequestHandler<ConsultarAplicacionesQuery, IReadOnlyList<ConsultarAplicacionesResponse>>
{
    private readonly ISeguridadQueryDBContext _seguridadQueryDBContext;

    public ConsultarAplicacionesQueryHandler(ISeguridadQueryDBContext seguridadQueryDBContext)
    {
        _seguridadQueryDBContext = seguridadQueryDBContext;
    }

    public async Task<IReadOnlyList<ConsultarAplicacionesResponse>> Handle(ConsultarAplicacionesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<ConsultarAplicacionesResponse> listaAplicaciones = await _seguridadQueryDBContext.Aplicaciones.Select(res => new ConsultarAplicacionesResponse(
            res.AplicacionId,
            res.NombreAplicacion,
            res.DescAplicacion,
            res.RutaUrl,
            res.Activo,
            res.CreaUsuario,
            res.CreaFecha,
            res.ModificaUsuario,
            res.ModificaFecha
            )).ToListAsync();

        return listaAplicaciones;
    }
}
