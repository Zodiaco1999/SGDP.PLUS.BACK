using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public class ConsultarPerfilPorIdQueryHandler : IRequestHandler<ConsultarPerfilPorIdQuery, ConsultarPerfilPorIdResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public ConsultarPerfilPorIdQueryHandler(IGestionPerfiles gestionPerfiles)
    {
        _gestionPerfiles = gestionPerfiles;
    }

    public async Task<ConsultarPerfilPorIdResponse> Handle(ConsultarPerfilPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarPerfilPorIdResponse res = await _gestionPerfiles.ConsultarPerfil(request.PerfilId);

        return res;
    }
}