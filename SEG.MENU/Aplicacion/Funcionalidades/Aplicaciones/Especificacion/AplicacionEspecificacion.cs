using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System.Linq.Expressions;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;

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
                var eEspecificacion1 = new SpecificationCriteriaDirect<Aplication>(c => c.NombreAplicacion.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Aplication>(c => c.DescAplicacion.Contains(s));
                var eEspecificacion3 = new SpecificationCriteriaDirect<Aplication>(c => c.RutaUrl.Contains(s));

                especificacion &= eEspecificacion1 || eEspecificacion2 || eEspecificacion3;
            }
        }

        return especificacion;
    }
}
