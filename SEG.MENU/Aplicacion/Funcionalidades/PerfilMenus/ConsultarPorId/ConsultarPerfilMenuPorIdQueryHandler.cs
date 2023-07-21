﻿using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public class ConsultarPerfilMenuPorIdQueryHandler : IRequestHandler<ConsultarPerfilMenuPorIdQuery, ConsultarPerfilMenuPorIdResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public ConsultarPerfilMenuPorIdQueryHandler(IGestionPerfilMenus gestionPerfilMenus)
    {
        _gestionPerfilMenus = gestionPerfilMenus;
    }

    public async Task<ConsultarPerfilMenuPorIdResponse> Handle(ConsultarPerfilMenuPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarPerfilMenuPorIdResponse res = await _gestionPerfilMenus.ConsultarPerfilMenuPorId(request.PerfilId);

        return res;
    }
}