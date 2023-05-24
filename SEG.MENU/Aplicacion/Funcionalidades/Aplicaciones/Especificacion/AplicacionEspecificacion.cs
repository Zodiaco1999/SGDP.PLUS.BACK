using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;
using System.Linq.Expressions;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;

public class AplicacionEspecificacion : SpecificationBase<Aplication>
{
    public AplicacionEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Aplication> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Aplication> especificacion = new SpecificationCriteriaTrue<Aplication>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {


                SpecificationCriteria<Aplication> especificacionSpl = new SpecificationCriteriaTrue<Aplication>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Aplication>(c => c.NombreAplicacion.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Aplication>(c => c.DescAplicacion.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}
