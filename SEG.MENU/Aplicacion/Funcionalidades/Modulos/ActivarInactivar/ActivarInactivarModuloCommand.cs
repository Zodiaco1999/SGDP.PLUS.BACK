using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ActivarInactivar;

public record struct ActivarInactivarModuloCommand(Guid ModuloId) : IRequest;