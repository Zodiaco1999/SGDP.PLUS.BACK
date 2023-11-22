using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Especificacion;

public class ModuloEspecificacion : SpecificationBase<Modulo>
{
    public ModuloEspecificacion(Guid aplicacionId, bool? activo)
    {
        Criteria = BusquedaModulo(aplicacionId, activo).SatisfiedBy();
    }

    private ISpecificationCriteria<Modulo> BusquedaModulo(Guid aplicacionId, bool? activo)
    {
        SpecificationCriteria<Modulo> especificacion = new SpecificationCriteriaTrue<Modulo>();

        var eEspecificacion1 = activo == null ? 
            new SpecificationCriteriaDirect<Modulo>(m =>  m.AplicacionId == aplicacionId) :
            new SpecificationCriteriaDirect<Modulo>(m => m.AplicacionId == aplicacionId && m.Activo == activo);

        especificacion &= eEspecificacion1;

        return especificacion;
    }

    private ISpecificationCriteria<Modulo> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<Modulo> especificacion = new SpecificationCriteriaTrue<Modulo>();

        var spl = texto.ToLower().Trim().Split(' ');

        return especificacion;
    }
}