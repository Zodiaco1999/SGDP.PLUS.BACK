﻿using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.Configuracion;

namespace SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

public class UnitOfWorkSegEscritura : UnitOfWorkBase, IUnitOfWorkSegEscritura
{
    public UnitOfWorkSegEscritura(DbContextOptions<UnitOfWorkSegEscritura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }
    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Seg
        modelBuilder.ApplyConfiguration(new TipoPersonaConfiguracion());
       
        #endregion
    }
}