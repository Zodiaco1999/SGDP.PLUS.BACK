using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;

public record struct EditarPerfilCommand(Guid PerfilId, string NombrePerfil, string DescPerfil) : IRequest<EditarPerfilResponse>;

