using MediatR;
using System.Drawing;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdQuery(string usuarioId) : IRequest<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>>;