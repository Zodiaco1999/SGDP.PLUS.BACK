using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;

public record struct EditarPerfilCommand(
    Guid PerfilId, 
    string NombrePerfil, 
    string DescPerfil,
    List<EditarPerfilMenuCommand> perfilMenus) : IRequest<EditarPerfilResponse>;

