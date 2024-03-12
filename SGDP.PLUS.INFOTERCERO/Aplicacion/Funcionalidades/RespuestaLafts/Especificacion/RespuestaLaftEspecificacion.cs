using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Especificacion;

public class RespuestaLaftEspecificacion : SpecificationBase<RespuestaLaft>
{
    public RespuestaLaftEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<RespuestaLaft> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<RespuestaLaft> especificacion = new SpecificationCriteriaTrue<RespuestaLaft>();

        var spl = texto.ToLower().Trim().Split(' ');

        return especificacion;
    }
}