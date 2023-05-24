using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Context;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;


public class AplicationRepositorioEscritura : Repository<Aplication>, IAplicationRepositorioEscritura
{
    public AplicationRepositorioEscritura(SeguridadCommandDBContext context) : base(context)
    {
    }
}