using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Context;
using System.CodeDom;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;

public class PerfilMenuRepositorioEscritura : Repository<PerfilMenu>, IPerfilMenuRepositorioEscritura
{
    public PerfilMenuRepositorioEscritura(SeguridadCommandDBContext context) : base(context)
    {    
    }
}
