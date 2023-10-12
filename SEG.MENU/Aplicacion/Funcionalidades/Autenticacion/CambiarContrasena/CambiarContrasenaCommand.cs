using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContrasena;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContraseña;

public record struct CambiarContrasenaCommand(string PasswordActual, string PasswordNueva) : IRequest<CambiarContrasenaResponse>;


