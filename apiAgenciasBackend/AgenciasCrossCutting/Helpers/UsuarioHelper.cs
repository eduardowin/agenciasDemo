using AgenciasCrossCutting.Dto.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgenciasCrossCutting.Helpers
{
    public class UsuarioHelper 
    {
        private readonly IConfiguration _configuration;
        private string  _vTokenAuthorization;
        public UsuarioHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UsuarioDto ObtenerUsuarioDeClaims(HttpContext pHttpContext)
        {
            _vTokenAuthorization = ObtenerFromRequestToken(pHttpContext);
            var oJwtHelper = new JwtHelper(_configuration);
            var vDataUsuario = oJwtHelper.ObtenerClaims(_vTokenAuthorization)?.FindFirst("vDataUsuario")?.Value;
            var oUsuarioLoginDto = vDataUsuario == null ? new UsuarioDto(): JsonConvert.DeserializeObject<UsuarioDto>(vDataUsuario);
            return oUsuarioLoginDto;
        }
        public string ObtenerTokenAutorization()
        {
            return _vTokenAuthorization;
        }
        public string ObtenerHeader(HttpRequest request, string pHeaderName)
        {
            var vHeader = string.Empty;

            foreach (var header in request.Headers)
            {
                if (header.Key == pHeaderName) return header.Value;
            };
            return string.Empty;
        }
        public string ObtenerFromRequestToken(HttpContext pHttpContext)
        {
            var tokenString = pHttpContext.Request.Headers["Authorization"].ToString();
            return tokenString.Replace("Bearer ", "");
        }
    }
}
