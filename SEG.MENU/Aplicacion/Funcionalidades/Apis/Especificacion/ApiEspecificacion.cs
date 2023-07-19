using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Especificacion;

public class ApiEspecificacion : SpecificationBase<Api>
{
    public ApiEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Api> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Api> especificacion = new SpecificationCriteriaTrue<Api>();

        var spl = texto.ToLower().Trim().Split(' ');

        return especificacion;
    }
}