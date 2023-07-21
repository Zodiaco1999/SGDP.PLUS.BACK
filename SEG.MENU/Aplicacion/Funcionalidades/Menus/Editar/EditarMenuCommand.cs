using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Editar;

public record struct EditarMenuCommand(
    Guid MenuId,
    string NombreMenu,
    string EtiquetaMenu,
    string DescMenu,
    string Url,
    short Orden,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta) : IRequest<EditarMenuResponse>;