using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Especificacion;

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