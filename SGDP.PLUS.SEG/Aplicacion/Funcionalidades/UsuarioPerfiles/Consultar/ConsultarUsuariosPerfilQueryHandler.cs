using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    public class ConsultarUsuariosPerfilQueryHandler : IRequestHandler<ConsultarUsuariosPerfilQuery, DataViewModel<ConsultarUsuariosPerfilResponse>>
    {
        private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;   
        public ConsultarUsuariosPerfilQueryHandler(IGestionUsuarioPerfil gestionUsuarioPerfil) => _gestionUsuarioPerfil = gestionUsuarioPerfil;
        
        public async Task<DataViewModel<ConsultarUsuariosPerfilResponse>> Handle(ConsultarUsuariosPerfilQuery request, CancellationToken cancellationToken)
            => await _gestionUsuarioPerfil.ConsultarUsuariosPerfil(request.Query, request.AplicaionId);

            
    }

