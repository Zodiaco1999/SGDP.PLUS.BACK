using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdResponse(
        string UsuarioId,
        Guid PerfilId,
        DateTime FechaInicia,
        DateTime FechaTermina,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);

