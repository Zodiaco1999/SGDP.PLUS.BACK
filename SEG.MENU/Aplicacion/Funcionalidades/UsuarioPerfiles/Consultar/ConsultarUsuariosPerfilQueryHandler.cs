﻿using MediatR;
using SEG.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    public class ConsultarUsuariosPerfilQueryHandler : IRequestHandler<ConsultarUsuariosPerfilQuery, DataViewModel<ConsultarUsuariosPerfilResponse>>
    {
        private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;   
        public ConsultarUsuariosPerfilQueryHandler(IGestionUsuarioPerfil gestionUsuarioPerfil) => _gestionUsuarioPerfil = gestionUsuarioPerfil;
        

        public async Task<DataViewModel<ConsultarUsuariosPerfilResponse>> Handle(ConsultarUsuariosPerfilQuery request, CancellationToken cancellationToken)
        {
            DataViewModel<ConsultarUsuariosPerfilResponse> result = await _gestionUsuarioPerfil.ConsultarUsuariosPerfil(request.textoBusqueda, request.pagina, request.registrosPorPagina);

            return result;
        }
    }

