using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public class ActivarInactivarAplicacionesCommandHandler : IRequestHandler<ActivarInactivarAplicacionesCommand, ActivarInactivarAplicacionesResponse>
{
    private readonly ISeguridadCommandDBContext _seguridadCommandDBContext;

    public ActivarInactivarAplicacionesCommandHandler(ISeguridadCommandDBContext seguridadCommandDBContext)
    {
        _seguridadCommandDBContext = seguridadCommandDBContext;
    }

    public async Task<ActivarInactivarAplicacionesResponse> Handle(ActivarInactivarAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var regActualizar = await _seguridadCommandDBContext.Aplicaciones
           .Where(x => x.AplicacionId == request.AplicacionId)
           .AsSplitQuery()
           .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualizar");
        }

        regActualizar.CambiarEstado(!regActualizar.Activo);

        await _seguridadCommandDBContext.SaveChangesAsync(cancellationToken);

        var regActualizado = await _seguridadCommandDBContext.Aplicaciones
           .Where(x => x.AplicacionId == request.AplicacionId)
           .AsSplitQuery()
           .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualziado");
        }

        return new ActivarInactivarAplicacionesResponse(
            regActualizado.AplicacionId,
            regActualizado.NombreAplicacion,
            regActualizado.DescAplicacion,
            regActualizado.RutaUrl,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}
