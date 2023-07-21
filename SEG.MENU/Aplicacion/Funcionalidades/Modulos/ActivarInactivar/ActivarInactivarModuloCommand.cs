using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ActivarInactivar;

public record struct ActivarInactivarModuloCommand(Guid ModuloId) : IRequest;