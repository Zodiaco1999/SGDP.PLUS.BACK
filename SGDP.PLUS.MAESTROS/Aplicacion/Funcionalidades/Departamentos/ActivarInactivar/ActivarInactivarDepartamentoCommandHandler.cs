using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ActivarInactivar;

public class ActivarInactivarDepartamentoCommandHandler : IRequestHandler<ActivarInactivarDepartamentoCommand, ActivarInactivarDepartamentoResponse>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public ActivarInactivarDepartamentoCommandHandler(IGestionDepartamentos gestionDepartamentos) => _gestionDepartamentos = gestionDepartamentos;

    public async Task<ActivarInactivarDepartamentoResponse> Handle(ActivarInactivarDepartamentoCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarDepartamentoResponse result = await _gestionDepartamentos.ActivarInactivarDepartamento(request.DepartamentoId);

        return result;
    }
}