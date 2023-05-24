using SEG.Comun.General;
using System;

namespace SEG.Comun.Entidades
{
    public class CamposLog : Entity
    {
        public string CreaUsuario { get; set; } = string.Empty;
        public DateTime CreaFecha { get; set; } = DateTime.Now;
        public string CreaMaquina { get; set; } = string.Empty;
        public string ModificaUsuario { get; set; } = string.Empty;
        public DateTime ModificaFecha { get; set; } = DateTime.Now;
        public string ModificaMaquina { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;
    }
}
