using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;

public record struct EditarPerfilMenuCommand(
    Guid PerfilId,
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta) : IRequest<EditarPerfilMenuResponse>;

