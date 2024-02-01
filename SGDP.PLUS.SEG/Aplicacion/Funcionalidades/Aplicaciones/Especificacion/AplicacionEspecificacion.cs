using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System.Linq.Expressions;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Especificacion;

public class AplicacionEspecificacion : SpecificationBase<Aplication>
{
    public AplicacionEspecificacion(string textoBusqueda)
    {
        if (!string.IsNullOrEmpty(textoBusqueda))
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
                especificacion &= new SpecificationCriteriaDirect<Aplication>(
                    a => a.NombreAplicacion.Contains(s)
                    || a.DescAplicacion.Contains(s)
                    || a.RutaUrl.Contains(s));
            }
        }

        return especificacion;
    }
}
