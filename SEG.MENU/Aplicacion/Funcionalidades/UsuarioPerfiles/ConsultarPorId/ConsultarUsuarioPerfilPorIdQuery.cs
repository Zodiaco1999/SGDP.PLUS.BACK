using MediatR;
using System.Drawing;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdQuery(Guid perfilId, string usuarioId) : IRequest<ConsultarUsuarioPerfilPorIdResponse>;