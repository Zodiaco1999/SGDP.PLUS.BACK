using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Especificacion;

public class ModuloEspecificacion : SpecificationBase<Modulo>
{
    public ModuloEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Modulo> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Modulo> especificacion = new SpecificationCriteriaTrue<Modulo>();

        var spl = texto.ToLower().Trim().Split(' ');

        return especificacion;
    }
}