using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

public interface IGestionPaises
{
    Task<DataViewModel<ConsultaPaisesResponse>> ConsultarPaises(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarPaisPorIdResponse> ConsultarPaisPorId(Guid paisId);
    Task<CrearPaisResponse> CrearPais(CrearPaisCommand registroDto);
    Task<EditarPaisResponse> EditarPais(EditarPaisCommand registroDto);
    Task<ActivarInactivarPaisResponse> ActivarInactivarPais(Guid paisId);
    Task<IEnumerable<ListaPaisesResponse>> ListaPaises();
}