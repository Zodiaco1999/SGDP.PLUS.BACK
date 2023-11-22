using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class TipoPersona : CamposLog
    {
        public Guid TipoPersonaId { get; set; } = Guid.NewGuid();
        public string NombreTipo { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

    }
}
