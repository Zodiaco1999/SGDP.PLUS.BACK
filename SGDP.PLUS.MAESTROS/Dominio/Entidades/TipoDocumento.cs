using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class TipoDocumento : CamposLog
    {
        public int TipoDocumentoId { get; set; }

        public string? Nombre { get; set; }

        public string? Abreviatura { get; set; }

        public bool Activo { get; set; }
        
    }
}
