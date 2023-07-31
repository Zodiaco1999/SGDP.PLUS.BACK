using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades
{
    public class Usuario : CamposLog
    {
        public string UsuarioId { get; set; } = null!;

        public string? UsuarioDominio { get; set; }

        public int? TipoDocumentoId { get; set; }

        public string? NumeroIdentificacion { get; set; }

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        public string Email { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string Genero { get; set; } = null!;

        public string? Contrasena { get; set; }

        public string? Salt { get; set; }

        public DateTime FechaActualizacionContrasena { get; set; }

        public string? Token { get; set; }

        public DateTime? FechaExpiracionToken { get; set; }

        public short? AccesosFallidos { get; set; }

        public DateTime? FechaBloqueo { get; set; }

        public string? CodigoAsignacion { get; set; }

        public DateTime? VenceCodigoAsignacion { get; set; }

        public bool? LogearLdap { get; set; }

        public bool Activo { get; set; }

        public virtual TipoDocumento? TipoDocumento { get; set; }

        public virtual UsuarioFoto? UsuarioFoto { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfiles { get; set; } = new List<UsuarioPerfil>();

        public virtual ICollection<UsuarioSesion> UsuarioSesions { get; set; } = new List<UsuarioSesion>();

    }
}
