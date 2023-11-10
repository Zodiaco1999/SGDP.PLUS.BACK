using Microsoft.IdentityModel.Tokens;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public DateTime Expiration => IssuedAt.Add(TimeSpan.FromMinutes(ValidForMinutes));
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public int ValidForMinutes { get; set; } = 1;
        public SigningCredentials SigningCredentials { get; set; } = null!;
    }
}