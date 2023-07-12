using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo);