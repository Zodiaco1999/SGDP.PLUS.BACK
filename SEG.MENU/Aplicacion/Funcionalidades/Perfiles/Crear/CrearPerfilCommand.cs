using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilCommand(
    string NombrePerfil, 
    string DescPerfil,
    List<CrearPerfilMenuCommand> PerfilMenus) : IRequest<CrearPerfilResponse>;
