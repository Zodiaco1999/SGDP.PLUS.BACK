using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

public record struct EditarPerfilCommand(Guid PerfilId, string NombrePerfil, string DescPerfil) : IRequest<EditarPerfilResponse>;

