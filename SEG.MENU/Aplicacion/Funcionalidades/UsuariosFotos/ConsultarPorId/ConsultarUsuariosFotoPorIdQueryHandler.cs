using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public class ConsultarUsuariosFotoPorIdQueryHandler : IRequestHandler<ConsultarUsuariosFotoPorIdQuery, ConsultarUsuariosFotoPorIdResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public ConsultarUsuariosFotoPorIdQueryHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<ConsultarUsuariosFotoPorIdResponse> Handle(ConsultarUsuariosFotoPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuariosFotoPorIdResponse result = await _gestionUsuariosFotos.ConsultarUsuariosFotosPorId(request.usuarioId);

        return result;
    }
}