using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;

public class PerfilMenuEspecificacion : SpecificationBase<PerfilMenu>
{
    public PerfilMenuEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<PerfilMenu> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<PerfilMenu> especificacion = new SpecificationCriteriaTrue<PerfilMenu>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<PerfilMenu> especificacionSpl = new SpecificationCriteriaTrue<PerfilMenu>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<PerfilMenu>(c => c.PerfilId.ToString().Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<PerfilMenu>(c => c.AplicacionId.ToString().Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}
