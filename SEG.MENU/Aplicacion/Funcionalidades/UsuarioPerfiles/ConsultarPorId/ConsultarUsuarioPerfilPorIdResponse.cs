using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdResponse(
    Guid PerfilId,
    string NombrePerfil,
    string NombreAplicacion,
    string DescPerfil,
    DateTime? FechaInicia,
    DateTime? FechaTermina,
    bool Activo);