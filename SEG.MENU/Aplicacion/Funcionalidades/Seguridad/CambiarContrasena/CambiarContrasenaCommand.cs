using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContrasena;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContraseña;

public record struct CambiarContrasenaCommand(
                                string Email,
                                string PasswordActual,
                                string PasswordNueva) : IRequest<CambiarContrasenaResponse>;


