using SGDP.PLUS.Comun.Especificacionbase;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Especificacion;
    public class UsuarioPerfilEspecificacion : SpecificationBase<UsuarioPerfil>
    {
        public UsuarioPerfilEspecificacion(string usuarioId, Guid? aplicacionId,string textoBusqueda, int? pagina = null, int? registrosPorPagina = null, string ordenarPor = null, string direccionOrdenamiento = "asc") 
        {
            Criteria = BusquedaTextoCompleto(usuarioId, aplicacionId, textoBusqueda).SatisfiedBy();
        }

    private ISpecificationCriteria<UsuarioPerfil> BusquedaTextoCompleto(string usuarioId, Guid? aplicacionId, string texto)
    {
        SpecificationCriteria<UsuarioPerfil> especificacion = new SpecificationCriteriaTrue<UsuarioPerfil>();

        especificacion = new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.UsuarioId == usuarioId);

        if (aplicacionId is not null)
        {
            especificacion &= new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.Perfil.PerfilMenus.FirstOrDefault().AplicacionId == aplicacionId); 
        }

        var spl = texto.ToLower().Trim().Split(' ');

        foreach (var s in spl)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                var eEspecificacion1 = new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.Perfil.NombrePerfil.Contains(s));
                var eEspecificacion2 = new SpecificationCriteriaDirect<UsuarioPerfil>(c => c.PerfilId.ToString().Contains(s));

                especificacion &= eEspecificacion1 || eEspecificacion2;
            }
        }

        return especificacion;
    }
}

