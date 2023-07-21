using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Especificacion;

public class PerfilEspecificacion : SpecificationBase<Perfil>
{
    public PerfilEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Perfil> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Perfil> especificacion = new SpecificationCriteriaTrue<Perfil>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Perfil> especificacionSpl = new SpecificationCriteriaTrue<Perfil>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Perfil>(c => c.NombrePerfil.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Perfil>(c => c.DescPerfil.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}
