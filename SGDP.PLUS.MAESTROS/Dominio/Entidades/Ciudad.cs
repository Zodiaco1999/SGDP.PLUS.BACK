using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.MAESTROS.Dominio.Entidades
{
    public class Ciudad : CamposLog
    {
        public Guid CiudadId { get; set; } = Guid.NewGuid();

        public Guid? DepartamentoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Codigo { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public virtual Departamento? Departamento { get; set; }
    }
}
