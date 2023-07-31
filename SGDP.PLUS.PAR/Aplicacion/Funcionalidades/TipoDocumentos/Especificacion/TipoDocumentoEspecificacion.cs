using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Especificacion;

public class TipoDocumentoEspecificacion : SpecificationBase<TipoDocumento>
{
    public TipoDocumentoEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<TipoDocumento> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<TipoDocumento> especificacion = new SpecificationCriteriaTrue<TipoDocumento>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<TipoDocumento> especificacionSpl = new SpecificationCriteriaTrue<TipoDocumento>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<TipoDocumento>(c => c.Nombre.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<TipoDocumento>(c => c.Abreviatura.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
                
            }
        }

        return especificacion;
    }
}