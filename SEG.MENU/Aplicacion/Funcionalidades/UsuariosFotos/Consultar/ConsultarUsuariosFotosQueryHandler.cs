using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

public class ConsultarUsuariosFotosQueryHandler : IRequestHandler<ConsultarUsuariosFotosQuery, DataViewModel<ConsultarUsuariosFotosResponse>>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public ConsultarUsuariosFotosQueryHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<DataViewModel<ConsultarUsuariosFotosResponse>> Handle(ConsultarUsuariosFotosQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarUsuariosFotosResponse> result = await _gestionUsuariosFotos.ConsultarUsuariosFotos   (request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}