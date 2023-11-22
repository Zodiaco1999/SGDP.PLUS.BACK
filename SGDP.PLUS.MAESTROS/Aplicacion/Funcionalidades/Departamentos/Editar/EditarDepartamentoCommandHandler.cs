using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;

public class EditarDepartamentoCommandHandler : IRequestHandler<EditarDepartamentoCommand, EditarDepartamentoResponse>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public EditarDepartamentoCommandHandler(IGestionDepartamentos gestionDepartamentos) => _gestionDepartamentos = gestionDepartamentos;

    public async Task<EditarDepartamentoResponse> Handle(EditarDepartamentoCommand request, CancellationToken cancellationToken)
    {
        EditarDepartamentoResponse result = await _gestionDepartamentos.EditarDepartamento(request!);

        return result;
    }
}