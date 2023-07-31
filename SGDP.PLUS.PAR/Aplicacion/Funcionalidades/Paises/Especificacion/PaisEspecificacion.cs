using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Especificacion;

public class PaisEspecificacion : SpecificationBase<Pais>
{
    public PaisEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Pais> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Pais> especificacion = new SpecificationCriteriaTrue<Pais>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if(!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Pais> especificacionSpl = new SpecificationCriteriaTrue<Pais>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Pais>(c => c.Nombre.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Pais>(c => c.Codigo.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}