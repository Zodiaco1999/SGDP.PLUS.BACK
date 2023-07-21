using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilCommand(string NombrePerfil, string DescPerfil) : IRequest<CrearPerfilResponse>;
