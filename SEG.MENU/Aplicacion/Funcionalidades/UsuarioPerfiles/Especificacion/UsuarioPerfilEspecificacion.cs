using SEG.Comun.Especificacionbase;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
    public class UsuarioPerfilEspecificacion : SpecificationBase<UsuarioPerfil>
    {
        public UsuarioPerfilEspecificacion(string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc") 
        {
            Criteria = BusquedaTextoCompleto(textoBusqueda).SatisfiedBy();
        }

    private ISpecificationCriteria<UsuarioPerfil> BusquedaTextoCompleto(string texto)
    {
        SpecificationCriteria<UsuarioPerfil> especificacion = new SpecificationCriteriaTrue<UsuarioPerfil>();

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                SpecificationCriteria<UsuarioPerfil> especificacionSpl = new SpecificationCriteriaTrue<UsuarioPerfil>();
                var eEspecificacion1 = new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.UsuarioId.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.PerfilId.ToString().Contains(s));

                especificacionSpl &= (eEspecificacion1 || eEspecificacion2);

                especificacion &= especificacionSpl;
            }
        }

        return especificacion;
    }
}

