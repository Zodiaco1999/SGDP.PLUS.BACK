using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

public interface IGestionDepartamentos
{
    Task<DataViewModel<ConsultarDepartamentosResponse>> ConsultarDepartamentos(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarDepartamentoPorIdResponse> ConsultarDepartamentoPorId(Guid departamentoId);
    Task<CrearDepartamentoResponse> CrearDepartamento(CrearDepartamentoCommand registroDto);
    Task<EditarDepartamentoResponse> EditarDepartamento(EditarDepartamentoCommand registroDto);
    Task<ActivarInactivarDepartamentoResponse> ActivarInactivarDepartamento(Guid departamentoId);
}