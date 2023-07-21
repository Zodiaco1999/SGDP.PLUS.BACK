using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public class ConsultarUsuarioFotoPorIdQueryHandler : IRequestHandler<ConsultarUsuarioFotoPorIdQuery, ConsultarUsuarioFotoPorIdResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public ConsultarUsuarioFotoPorIdQueryHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<ConsultarUsuarioFotoPorIdResponse> Handle(ConsultarUsuarioFotoPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuarioFotoPorIdResponse result = await _gestionUsuariosFotos.ConsultarUsuarioFotoPorId(request.usuarioId);

        return result;
    }
}