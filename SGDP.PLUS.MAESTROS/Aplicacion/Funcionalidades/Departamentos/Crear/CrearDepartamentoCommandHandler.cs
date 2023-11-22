using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;

public class CrearDepartamentoCommandHandler : IRequestHandler<CrearDepartamentoCommand, CrearDepartamentoResponse>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public CrearDepartamentoCommandHandler(IGestionDepartamentos gestionDepartamentos) => _gestionDepartamentos = gestionDepartamentos;

    public async Task<CrearDepartamentoResponse> Handle(CrearDepartamentoCommand request, CancellationToken cancellationToken)
    {
        CrearDepartamentoResponse result = await _gestionDepartamentos.CrearDepartamento(request);

        return result;
    }
}