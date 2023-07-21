using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Especificacion;

public class UsuarioSesionEspecificacion : SpecificationBase<UsuarioSesion>
{
    public UsuarioSesionEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<UsuarioSesion> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<UsuarioSesion> especificacion = new SpecificationCriteriaTrue<UsuarioSesion>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<UsuarioSesion> especificacionSpl = new SpecificationCriteriaTrue<UsuarioSesion>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<UsuarioSesion>(c => c.UsuarioId.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<UsuarioSesion>(c => c.SesionId.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}