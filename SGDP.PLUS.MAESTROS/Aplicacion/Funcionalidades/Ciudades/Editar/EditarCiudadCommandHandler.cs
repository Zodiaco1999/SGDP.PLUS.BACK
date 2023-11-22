using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;

public class EditarCiudadCommandHandler : IRequestHandler<EditarCiudadCommand, EditarCiudadResponse>
{
    private readonly IGestionCiudades _gestionCiudades;
    public EditarCiudadCommandHandler(IGestionCiudades gestionCiudades) => _gestionCiudades = gestionCiudades;

    public async Task<EditarCiudadResponse> Handle(EditarCiudadCommand request, CancellationToken cancellationToken)
    {
        EditarCiudadResponse result = await _gestionCiudades.EditarCiudad(request);

        return result;
    }
}