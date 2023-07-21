using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;

public record struct CrearMenuCommand(
    Guid AplicacionId,
    Guid ModuloId,
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
    bool Ejecuta) : IRequest<CrearMenuResponse>;