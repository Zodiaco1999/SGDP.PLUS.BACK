using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public class EditarAplicacionesCommandHandler : IRequestHandler<EditarAplicacionesCommand, EditarAplicacionesResponse>
{
    private readonly ISeguridadCommandDBContext _seguridadCommandDBContext;

    public EditarAplicacionesCommandHandler(ISeguridadCommandDBContext seguridadCommandDBContext)
    {
        _seguridadCommandDBContext = seguridadCommandDBContext;
    }

    public async Task<EditarAplicacionesResponse> Handle(EditarAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var regActualizar = await _seguridadCommandDBContext.Aplicaciones
           .Where(x => x.AplicacionId == request.AplicacionId)
           .AsSplitQuery()
           .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Aplication),"No se encontró el registro a actualizar");
        }

        regActualizar.ActualizarRegistro(request.NombreAplicacion, request.DescAplicacion, request.RutaUrl);

        await _seguridadCommandDBContext.SaveChangesAsync(cancellationToken);

        var regActualizado = await _seguridadCommandDBContext.Aplicaciones
           .Where(x => x.AplicacionId == request.AplicacionId)
           .AsSplitQuery()
           .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Aplication), "No se encontró el registro a actualziado");
        }

        return new EditarAplicacionesResponse(
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
