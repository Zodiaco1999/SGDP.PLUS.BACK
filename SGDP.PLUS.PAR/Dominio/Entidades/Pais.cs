using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class Pais : CamposLog
    {
        public Guid PaisId { get; set; } = Guid.NewGuid();

        public string? Nombre { get; set; } = string.Empty;

        public string? Codigo { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
