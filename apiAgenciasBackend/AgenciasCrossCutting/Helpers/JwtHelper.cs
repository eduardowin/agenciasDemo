using AgenciasCrossCutting.Dto.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgenciasCrossCutting.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto BuildToken(UsuarioDto pUsuarioLogin)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, pUsuarioLogin.UsuarioId),
                new Claim("vDataUsuario", JsonConvert.SerializeObject(pUsuarioLogin)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims);

            //TODO: appsetting for Demo JWT - protect correctly this settings
            var secretKey = _configuration["JWT:key"];
            var audienceToken = _configuration["JWT:Audience_Token"];
            var issuerToken = _configuration["JWT:Issuer_Token"];
            var expireTime = _configuration["JWT:Expire_Minutes"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime));

            // create token to the user 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: signingCredentials);

            return new TokenDto()
            {
                Token = tokenHandler.WriteToken(jwtSecurityToken),
                Expiration = expiration
            };
        }

        public ClaimsPrincipal ObtenerClaims(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            var secretKey = _configuration["JWT:key"];
            var audienceToken = _configuration["JWT:Audience_Token"];
            var issuerToken = _configuration["JWT:Issuer_Token"];
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

            SecurityToken securityToken;
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = audienceToken,
                ValidIssuer = issuerToken,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = this.LifetimeValidator,
                IssuerSigningKey = securityKey
            };

            var principal = new ClaimsPrincipal();
            
            try
            {
                principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out securityToken);
            }
            catch (Exception e)
            {

            }
            // Extract and assign Current Principal and user

            return principal;
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
