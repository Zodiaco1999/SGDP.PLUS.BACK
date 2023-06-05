using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;

public record struct EditarPerfilMenusCommand(
    Guid PerfilId,
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta) : IRequest<EditarPerfilMenusResponse>;

