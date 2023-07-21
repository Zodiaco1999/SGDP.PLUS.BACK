using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

public interface IGestionModulos
{
    Task<CrearModuloResponse> CrearModulo(CrearModuloCommand registroDto);
    Task EditarModulo(EditarModuloCommand registroDto);
    Task ActivarInactivarModulo(Guid moduloId);
}