using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;

            if (_jwtOptions == null) throw new ArgumentNullException(nameof(jwtOptions));
            if (_jwtOptions.ValidForMinutes <= 0)
            {
                throw new ArgumentException("Debe ser mayor a 0", nameof(JwtOptions.ValidForMinutes));
            }
            if (_jwtOptions.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtOptions.SigningCredentials));
            }
        }

        public string GenerateEncodedToken(string userName, ClaimsIdentity identity, string refreshToken)
        {
            var expiration = _jwtOptions.Expiration;

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _jwtOptions.Issuer,
               audience: _jwtOptions.Audience,
               claims: identity.Claims,
               notBefore: _jwtOptions.NotBefore,
               expires: expiration,
               signingCredentials: _jwtOptions.SigningCredentials
               );

            return JsonConvert.SerializeObject(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration,
                refreshToken
            });
        }

        public JwtSecurityToken DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(token);
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            return jsonToken;
        }
    }
}