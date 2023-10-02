using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;

public class PerfilMenuEspecificacion : SpecificationBase<PerfilMenu>
{
    public PerfilMenuEspecificacion(Guid perfilId, Guid? moduloId, string textoBusqueda, int? pagina = null,
        int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaParametros(perfilId, moduloId, textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<PerfilMenu> BusquedaParametros(Guid perfilId, Guid? moduloId, string texto)
    {
        SpecificationCriteria<PerfilMenu> especificacion = new SpecificationCriteriaTrue<PerfilMenu>();

        especificacion = new SpecificationCriteriaDirect<PerfilMenu>(c => c.PerfilId == perfilId);

        if (moduloId is not null)
        {
            especificacion &= new SpecificationCriteriaDirect<PerfilMenu>(c => c.ModuloId == moduloId);
        }

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                var eEspecificacion1 = new SpecificationCriteriaDirect<PerfilMenu>(c => c.Menu.NombreMenu.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<PerfilMenu>(c => c.Menu.DescMenu.Contains(s));

                especificacion &= eEspecificacion1 || eEspecificacion2;
            }
        }

        return especificacion;
    }

}
