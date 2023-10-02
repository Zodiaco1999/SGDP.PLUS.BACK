using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.EnviarCorreoContrasena;
public record struct EnviarCorreoContrasenaCommand(
                        string Email) : IRequest<EnviarCorreoContrasenaResponse>;