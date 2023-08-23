using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class Departamento : CamposLog
    {
        public Guid DepartamentoId { get; set; } = Guid.NewGuid();

        public Guid? PaisId { get; set; }

        public string? Nombre { get; set; } = string.Empty;

        public string? Codigo { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

        public virtual Pais? Pais { get; set; }
    }
}
