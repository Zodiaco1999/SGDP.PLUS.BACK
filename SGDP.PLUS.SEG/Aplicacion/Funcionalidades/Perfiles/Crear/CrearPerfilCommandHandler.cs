using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;

public class CrearPerfilCommandHandler : IRequestHandler<CrearPerfilCommand, CrearPerfilResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public CrearPerfilCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<CrearPerfilResponse> Handle(CrearPerfilCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfiles.CrearPerfil(request);
    }
}
