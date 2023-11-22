using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

public interface IGestionCiudades
{
    Task<DataViewModel<ConsultarCiudadesResponse>> ConsultarCiudades(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarCiudadPorIdResponse> ConsultarCiudadPorId(Guid ciudadId);
    Task<CrearCiudadResponse> CrearCiudad(CrearCiudadCommand registroDto);
    Task<EditarCiudadResponse> EditarCiudad(EditarCiudadCommand registroDto);
    Task<ActivarInactivarCiudadResponse> ActivarInactivarCiudad(Guid ciudadId);
}