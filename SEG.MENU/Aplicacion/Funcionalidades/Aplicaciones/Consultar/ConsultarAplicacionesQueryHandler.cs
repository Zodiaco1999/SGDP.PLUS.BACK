using MediatR;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Aplicacion.Interfaces;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public class ConsultarAplicacionesQueryHandler : IRequestHandler<ConsultarAplicacionesQuery, IReadOnlyList<ConsultarAplicacionesResponse>>
{
    private readonly ISeguridadQueryDBContext _seguridadQueryDBContext;
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public ConsultarAplicacionesQueryHandler(ISeguridadQueryDBContext seguridadQueryDBContext, IGestionAplicaciones gestionAplicaciones)
    {
        _seguridadQueryDBContext = seguridadQueryDBContext;
        _gestionAplicaciones = gestionAplicaciones;
    }

    public async Task<IReadOnlyList<ConsultarAplicacionesResponse>> Handle(ConsultarAplicacionesQuery request, CancellationToken cancellationToken)
    {
        if(request.textoBusqueda != null)
        {
            var res = await _gestionAplicaciones.ConsultarAplicaciones(request.textoBusqueda, request.pagina, request.registrosPorPagina);
            return res.Items;
        }        
        

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
