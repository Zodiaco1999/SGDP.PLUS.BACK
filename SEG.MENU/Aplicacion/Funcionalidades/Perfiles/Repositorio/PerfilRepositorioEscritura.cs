using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Context;
using System.CodeDom;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;

public class PerfilRepositorioEscritura : Repository<Perfil>, IPerfilRepositorioEscritura
{
    public PerfilRepositorioEscritura(SeguridadCommandDBContext context) : base(context)
    {    
    }
}
