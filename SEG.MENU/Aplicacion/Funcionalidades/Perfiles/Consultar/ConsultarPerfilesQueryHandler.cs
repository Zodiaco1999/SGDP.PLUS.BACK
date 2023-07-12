using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;

public class ConsultarPerfilesQueryHandler : IRequestHandler<ConsultarPerfilesQuery, DataViewModel<ConsultarPerfilesResponse>>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public ConsultarPerfilesQueryHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<DataViewModel<ConsultarPerfilesResponse>> Handle(ConsultarPerfilesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarPerfilesResponse> res = await _gestionPerfiles.ConsultarPerfiles(request.textoBusqueda, request.pagina, request.registrosPorPagina);
        return res;
    }
}
