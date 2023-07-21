using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public record struct ConsultarUsuarioPerfilPorIdResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo);