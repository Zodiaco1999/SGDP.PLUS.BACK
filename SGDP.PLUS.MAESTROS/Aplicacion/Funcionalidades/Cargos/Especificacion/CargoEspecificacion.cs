using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Especificacion;

public class CargoEspecificacion : SpecificationBase<Cargo>
{
    public CargoEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Cargo> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Cargo> especificacion = new SpecificationCriteriaTrue<Cargo>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Cargo> especificacionSpl = new SpecificationCriteriaTrue<Cargo>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Cargo>(c => c.Nombre.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Cargo>(c => c.Abreviatura.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}