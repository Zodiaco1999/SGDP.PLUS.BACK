using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;

public class ConsultarUsuarioPorIdQueryHandler : IRequestHandler<ConsultarUsuarioPorIdQuery, ConsultarUsuarioPorIdResponse>
{
    private readonly IGestionUsuarios _gestionUsuarios;
    public ConsultarUsuarioPorIdQueryHandler(IGestionUsuarios gestionUsuarios) => _gestionUsuarios = gestionUsuarios;

    public async Task<ConsultarUsuarioPorIdResponse> Handle(ConsultarUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuarioPorIdResponse result = await _gestionUsuarios.ConsultarUsuarioPorId(request.usuarioId);

        return result;
    }
}