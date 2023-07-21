using SEG.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Especificacion;

public class UsuarioSesionLogEspecificacion : SpecificationBase<UsuarioSesionLog>
{
    public UsuarioSesionLogEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc")
    {
        Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
    }

    private ISpecificationCriteria<UsuarioSesionLog> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<UsuarioSesionLog> especificacion = new SpecificationCriteriaTrue<UsuarioSesionLog>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<UsuarioSesionLog> especificacionSpl = new SpecificationCriteriaTrue<UsuarioSesionLog>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<UsuarioSesionLog>(c => c.UsuarioId.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<UsuarioSesionLog>(c => c.SesionId.Contains(s));
                var eEspecificacion3 = new SpecificationCriteriaDirect<UsuarioSesionLog>(c => c.LogId.ToString().Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2 || eEspecificacion3);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}