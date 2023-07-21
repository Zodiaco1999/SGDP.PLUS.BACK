using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;

public record struct ActivarInactivarUsuarioCommand(string UsuarioId) : IRequest<ActivarInactivarUsuarioResponse>;