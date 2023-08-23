using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Especificacion;

public class TipoPersonaEspecificacion : SpecificationBase<TipoPersona>
{
    public TipoPersonaEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<TipoPersona> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<TipoPersona> especificacion = new SpecificationCriteriaTrue<TipoPersona>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<TipoPersona> especificacionSpl = new SpecificationCriteriaTrue<TipoPersona>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<TipoPersona>(c => c.NombreTipo.Contains(s));

                especificacionSpl &= (eEspecificacion1);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}