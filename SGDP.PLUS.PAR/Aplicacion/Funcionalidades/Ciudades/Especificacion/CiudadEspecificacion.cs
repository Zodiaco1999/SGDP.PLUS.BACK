using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Especificacion;

public class CiudadEspecificacion : SpecificationBase<Ciudad>
{
    public CiudadEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Ciudad> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Ciudad> especificacion = new SpecificationCriteriaTrue<Ciudad>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Ciudad> especificacionSpl = new SpecificationCriteriaTrue<Ciudad>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Ciudad>(c => c.Nombre.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Ciudad>(c => c.Codigo.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}