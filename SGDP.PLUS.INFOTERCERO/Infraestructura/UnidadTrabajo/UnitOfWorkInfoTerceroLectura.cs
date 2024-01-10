using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroLectura : UnitOfWorkBase, IUnitOfWorkInfoTerceroLectura
{
    public UnitOfWorkInfoTerceroLectura(DbContextOptions<UnitOfWorkInfoTerceroLectura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }

    public virtual DbSet<InfoBasica> InfoBasica { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InfoBasicaConfiguracion());
        modelBuilder.ApplyConfiguration(new RespuestaLaftConfiguracion());
        modelBuilder.ApplyConfiguration(new IlicitosRespuestaConfiguracion()); 
    }
}
