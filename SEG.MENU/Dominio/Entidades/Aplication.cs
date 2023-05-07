﻿using Ardalis.GuardClauses;
using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Aplication : CamposLog
{
    public Guid AplicacionId { get; set; } = Guid.NewGuid();
    public string NombreAplicacion { get; set; } = string.Empty;
    public string DescAplicacion { get; set; } = string.Empty;
    public string RutaUrl { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;

    private Aplication(string nombreAplicacion, string descAplicacion, string rutaUrl)
    {
        AplicacionId = Guid.NewGuid();
        NombreAplicacion = Guard.Against.NullOrWhiteSpace(nombreAplicacion);
        DescAplicacion = Guard.Against.NullOrWhiteSpace(descAplicacion);
        RutaUrl = Guard.Against.NullOrWhiteSpace(rutaUrl);
        Activo = true;
    }

    public static Aplication CrearRegistro(string nombreAplicacion, string descAplicacion, string rutaUrl)
    {
        return new Aplication(nombreAplicacion, descAplicacion, rutaUrl);
    }
}
