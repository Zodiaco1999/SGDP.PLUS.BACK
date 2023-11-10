using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGDP.PLUS.Comun.Seguridad.Entidades;

public class ParametrosSEG
{
    public int TiempoBloqueo { get; set; }
    public int AccesosFallidos { get; set; }
    // Solo para pruebas
    public bool ValidarContrasena { get; set; }
    public string PatronContrasena { get; set; } = string.Empty;
    public string MensajeValidacionContrasena { get; set; } = string.Empty;
}
