using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;

public interface IJwtFactory
{
    string GenerateEncodedToken(string userName, ClaimsIdentity identity, string refreshToken);
    JwtSecurityToken DecodeToken(string token);
}