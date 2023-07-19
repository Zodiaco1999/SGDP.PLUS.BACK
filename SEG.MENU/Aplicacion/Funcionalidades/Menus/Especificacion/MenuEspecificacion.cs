using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Especificacion;

public class MenuEspecificacion : SpecificationBase<Menu>
{
    public MenuEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Menu> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Menu> especificacion = new SpecificationCriteriaTrue<Menu>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Menu> especificacionSpl = new SpecificationCriteriaTrue<Menu>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Menu>(c => c.NombreMenu.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Menu>(c => c.EtiquetaMenu.Contains(s));
                var eEspecificacion3 = new SpecificationCriteriaDirect<Menu>(c => c.DescMenu.Contains(s));
                var eEspecificacion4 = new SpecificationCriteriaDirect<Menu>(c => c.Url.Contains(s));

                especificacion &= eEspecificacion1 || eEspecificacion2 || eEspecificacion3 || eEspecificacion4;
            }
        }

        return especificacion;
    }
}