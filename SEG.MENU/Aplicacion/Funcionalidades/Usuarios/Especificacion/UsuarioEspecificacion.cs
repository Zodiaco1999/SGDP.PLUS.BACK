using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Especificacion;

public class UsuarioEspecificacion : SpecificationBase<Usuario>
{
    public UsuarioEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Usuario> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Usuario> especificacion = new SpecificationCriteriaTrue<Usuario>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Usuario> especificacionSpl = new SpecificationCriteriaTrue<Usuario>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Usuario>(c => c.UsuarioId.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Usuario>(c => c.PrimerNombre.Contains(s));
                var eEspecificacion3 = new SpecificationCriteriaDirect<Usuario>(c => c.PrimerApellido.Contains(s));
                var eEspecificacion4 = new SpecificationCriteriaDirect<Usuario>(c => c.Email.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2 || eEspecificacion3 || eEspecificacion4);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}