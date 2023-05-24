using Ardalis.GuardClauses;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

public class GestionAplicaciones : IGestionAplicaciones
{
    private readonly IAplicationRepositorioLectura _aplicacionRepositorioLectura;
    private readonly IAplicationRepositorioEscritura _aplicacionRepositorioEscritura;
    public GestionAplicaciones(IAplicationRepositorioLectura aplicacionRepositorioLectura, IAplicationRepositorioEscritura aplicacionRepositorioEscritura)
    {
        _aplicacionRepositorioLectura = aplicacionRepositorioLectura;
        _aplicacionRepositorioEscritura = aplicacionRepositorioEscritura;

    }

    public async Task<ConsultaViewModel<ConsultarAplicacionesResponse>> ConsultarAplicaciones(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = false)
    {
        
        try
        {
            var filtroEspecificacion = new AplicacionEspecificacion(filtro);

            ConsultaViewModel<ConsultarAplicacionesResponse> consulta = new ConsultaViewModel<ConsultarAplicacionesResponse>();

            var result = await _aplicacionRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                //.OrderBy("", true)
                .SelectPageAsync(pagina, registrosPorPagina);

            consulta.TotalRegistros = result.TotalItems;
            consulta.Items = new List<ConsultarAplicacionesResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarAplicacionesResponse(
                                item.AplicacionId,
                                item.NombreAplicacion,
                                item.DescAplicacion,
                                item.RutaUrl,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha
                                );
                consulta.Items.Add(det);
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Aplication), ex.Message);
        }
    }

    public async  Task<CrearAplicacionesResponse> CreaAplicacion(Aplication registro)
    {

        CrearAplicacionesResponse crearAplicacionesResponse = new CrearAplicacionesResponse(registro.AplicacionId, registro.NombreAplicacion, registro.DescAplicacion, registro.RutaUrl, registro.Activo);

        await _aplicacionRepositorioEscritura.InsertAsync(registro);

        return crearAplicacionesResponse;
    }

    public Task ActualizaAplicacion(EditarAplicacionesResponse registroDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ConsultarAplicacionesResponse> ConsultarAplicacion(Guid aplicacionId)
    {
        throw new NotImplementedException();
    }        

    public Task ActivarInactivar(Guid aplicacionId)
    {
        throw new NotImplementedException();
    }
}
