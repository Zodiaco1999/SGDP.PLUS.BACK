using SEG.MENU.Aplicacion.Funcionalidades.Modulos.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Modulos.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

public interface IGestionModulos
{
    Task<CrearModuloResponse> CrearModulo(CrearModuloCommand registroDto);
    Task EditarModulo(EditarModuloCommand registroDto);
    Task ActivarInactivarModulo(Guid moduloId);
}