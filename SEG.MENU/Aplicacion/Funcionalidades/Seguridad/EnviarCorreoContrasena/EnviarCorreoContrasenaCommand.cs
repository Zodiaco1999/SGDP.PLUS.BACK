using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.EnviarCorreoContrasena;
public record struct EnviarCorreoContrasenaCommand(
                        string Email) : IRequest<EnviarCorreoContrasenaResponse>;