using Microsoft.EntityFrameworkCore;
using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Context;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio
{
    public class AplicationRepositorioLectura : Repository<Aplication>, IAplicationRepositorioLectura
    {
        public AplicationRepositorioLectura(SeguridadQueryDBContext context) : base(context) 
        {
        }
    }
}
