﻿using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroEscritura : UnitOfWorkBase, IUnitOfWorkInfoTerceroEscritura
{
    public UnitOfWorkInfoTerceroEscritura(DbContextOptions<UnitOfWorkInfoTerceroEscritura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InfoBasicaConfiguracion());
        modelBuilder.ApplyConfiguration(new AdministradorConfiguracion());
        modelBuilder.ApplyConfiguration(new RespuestaLaftConfiguracion());
        modelBuilder.ApplyConfiguration(new IlicitosRespuestaConfiguracion());
    }
}
