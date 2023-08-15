using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

public interface IGestionModulos
{
    Task<CrearModuloResponse> CrearModulo(CrearModuloCommand registroDto);
    Task EditarModulo(EditarModuloCommand registroDto);
    Task ActivarInactivarModulo(Guid moduloId);
    Task<ConsultarModuloPorIdResponse> ConsultarModuloPorId(Guid moduloId);
    Task<IEnumerable<ConsultarModulosResponse>> ConsultarModulos(Guid aplicacionId);
}