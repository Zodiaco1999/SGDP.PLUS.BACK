﻿using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;

public class ConsultarMenuUsuarioQueryHandler : IRequestHandler<ConsultarMenuUsuarioQuery, IEnumerable<ConsultarMenuUsuarioResponse>>
{
    private readonly IGestionMenus _gestionMenus;
    public ConsultarMenuUsuarioQueryHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;
    public Task<IEnumerable<ConsultarMenuUsuarioResponse>> Handle(ConsultarMenuUsuarioQuery request, CancellationToken cancellationToken)
        => _gestionMenus.ConsultarMenuUsuario();
}
