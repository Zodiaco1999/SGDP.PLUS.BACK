using SEG.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
public class UsuarioFotoEspecificacion : SpecificationBase<UsuarioFoto>
{
    public UsuarioFotoEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<UsuarioFoto> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<UsuarioFoto> especificacion = new SpecificationCriteriaTrue<UsuarioFoto>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<UsuarioFoto> especificacionSpl = new SpecificationCriteriaTrue<UsuarioFoto>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<UsuarioFoto>(c => c.UsuarioId.Contains(s));

                especificacionSpl &= (eEspecificacion1);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}

