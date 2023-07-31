using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Especificacion;

public class DepartamentoEspecificacion : SpecificationBase<Departamento>
{
    public DepartamentoEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<Departamento> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Departamento> especificacion = new SpecificationCriteriaTrue<Departamento>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<Departamento> especificacionSpl = new SpecificationCriteriaTrue<Departamento>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<Departamento>(c => c.Nombre.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<Departamento>(c => c.Codigo.Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}