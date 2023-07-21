using MediatR;
using System.Drawing;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdQuery(string usuarioId) : IRequest<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>>;