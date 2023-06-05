using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

public record struct EditarPerfilesCommand(Guid PerfilId, string NombrePerfil, string DescPerfil) : IRequest<EditarPerfilesResponse>;

