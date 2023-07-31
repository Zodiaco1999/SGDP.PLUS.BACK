using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

public interface IGestionCargos
{
    Task<DataViewModel<ConsultarCargosResponse>> ConsultarCargos(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarCargoPorIdResponse> ConsultarCargoPorId(Guid cargoId);
    Task<CrearCargoResponse> CrearCargo(CrearCargoCommand registroDto);
    Task<EditarCargoResponse> EditarCargo(EditarCargoCommand registroDto);
    Task<ActivarInactivarCargoResponse> ActivarInactivarCargo(Guid cargoId);
}