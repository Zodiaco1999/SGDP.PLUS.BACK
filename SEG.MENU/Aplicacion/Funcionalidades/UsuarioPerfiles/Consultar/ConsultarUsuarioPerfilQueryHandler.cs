using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    public class ConsultarUsuarioPerfilQueryHandler : IRequestHandler<ConsultarUsuarioPerfilQuery, DataViewModel<ConsultarUsuarioPerfilResponse>>
    {
        private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;   
        public ConsultarUsuarioPerfilQueryHandler(IGestionUsuarioPerfil gestionUsuarioPerfil) => _gestionUsuarioPerfil = gestionUsuarioPerfil;
        

        public async Task<DataViewModel<ConsultarUsuarioPerfilResponse>> Handle(ConsultarUsuarioPerfilQuery request, CancellationToken cancellationToken)
        {
            DataViewModel<ConsultarUsuarioPerfilResponse> res = await _gestionUsuarioPerfil.ConsultarUsuariosPerfil(request.textoBusqueda, request.pagina, request.registrosPorPagina);
            return res;
        }
    }

