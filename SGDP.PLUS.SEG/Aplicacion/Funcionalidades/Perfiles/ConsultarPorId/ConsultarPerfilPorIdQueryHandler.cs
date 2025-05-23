﻿using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public class ConsultarPerfilPorIdQueryHandler : IRequestHandler<ConsultarPerfilPorIdQuery, ConsultarPerfilPorIdResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;
    public ConsultarPerfilPorIdQueryHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<ConsultarPerfilPorIdResponse> Handle(ConsultarPerfilPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarPerfilPorIdResponse res = await _gestionPerfiles.ConsultarPerfilPorId(request.PerfilId);

        return res;
    }
}