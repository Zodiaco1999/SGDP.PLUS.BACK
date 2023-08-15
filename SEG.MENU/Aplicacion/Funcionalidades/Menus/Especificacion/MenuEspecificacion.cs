using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Especificacion;

public class MenuEspecificacion : SpecificationBase<Menu>
{
    public Guid AplicacionId { get; set; }
    public Guid? ModuloId { get; set; }
    public MenuEspecificacion(Guid aplicacionId, Guid? moduloId, string textoBusqueda, int? pagina = null,
        int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        AplicacionId = aplicacionId;
        ModuloId = moduloId;
        Criteria = BusquedaFiltro(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Menu> BusquedaFiltro(string texto)
    {
        SpecificationCriteria<Menu> especificacion = new SpecificationCriteriaTrue<Menu>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                var eEspecificacion1 = new SpecificationCriteriaDirect<Menu>(c => c.NombreMenu.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Menu>(c => c.EtiquetaMenu.Contains(s));
                var eEspecificacion3 = new SpecificationCriteriaDirect<Menu>(c => c.DescMenu.Contains(s));
                var eEspecificacion4 = new SpecificationCriteriaDirect<Menu>(c => c.Url.Contains(s));

                especificacion &= eEspecificacion1 || eEspecificacion2 || eEspecificacion3 || eEspecificacion4;
            }
        }

        var eEspecificacionId = ModuloId != null ? new SpecificationCriteriaDirect<Menu>(c => c.AplicacionId == AplicacionId && c.ModuloId == ModuloId) :
            new SpecificationCriteriaDirect<Menu>(c => c.AplicacionId == AplicacionId);

        especificacion &= eEspecificacionId;

        return especificacion;
    }
}