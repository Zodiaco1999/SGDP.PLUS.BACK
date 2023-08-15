using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;

public class PerfilMenuEspecificacion : SpecificationBase<PerfilMenu>
{
    public PerfilMenuEspecificacion(Guid perfilId, Guid? aplicaionId, Guid? moduloId,
        string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaParametros(perfilId, aplicaionId, moduloId, textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<PerfilMenu> BusquedaParametros(Guid perfilId, Guid? aplicacionId, Guid? moduloId, string texto)
    {
        SpecificationCriteria<PerfilMenu> especificacion = new SpecificationCriteriaTrue<PerfilMenu>();

        especificacion = new SpecificationCriteriaDirect<PerfilMenu>(c => c.PerfilId == perfilId);

        if (aplicacionId is not null)
        {
            var eEspecificacionIds = moduloId is not null ? 
                new SpecificationCriteriaDirect<PerfilMenu>(c => c.AplicacionId == aplicacionId && c.ModuloId == moduloId) :
                new SpecificationCriteriaDirect<PerfilMenu>(c => c.AplicacionId == aplicacionId);

            especificacion &= eEspecificacionIds;
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
