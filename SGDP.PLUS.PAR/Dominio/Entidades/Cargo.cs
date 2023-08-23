using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class Cargo : CamposLog
    {
        public Guid CargoId { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Abreviatura { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}
