using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;

public record struct ConsultarMenuUsuarioQuery() : IRequest<IEnumerable<ConsultarMenuUsuarioResponse>>;
