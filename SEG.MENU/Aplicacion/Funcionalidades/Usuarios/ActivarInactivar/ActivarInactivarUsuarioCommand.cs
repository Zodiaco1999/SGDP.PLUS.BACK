using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;

public record struct ActivarInactivarUsuarioCommand(string UsuarioId) : IRequest<ActivarInactivarUsuarioResponse>;