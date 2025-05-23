using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;

public class ConsultarUsuariosQueryHandler : IRequestHandler<ConsultarUsuariosQuery, DataViewModel<ConsultarUsuariosResponse>>
{
    private readonly IGestionUsuarios _gestionUsuarios;
    public ConsultarUsuariosQueryHandler(IGestionUsuarios gestionUsuarios) => _gestionUsuarios = gestionUsuarios;

    public async Task<DataViewModel<ConsultarUsuariosResponse>> Handle(ConsultarUsuariosQuery request, CancellationToken cancellationToken)
        => await _gestionUsuarios.ConsultarUsuarios(request.query);
}