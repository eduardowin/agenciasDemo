using AgenciaRepository.Interfaces;
using AgenciasCrossCutting.Dto.Agencias;
using AgenciaService.Interfaces;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaService.Implementations
{
    public class AgenciaService : IAgenciaService
    {
        private readonly IConfiguration _configuration;
        public AgenciaService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<List<AgenciaDto>> GetAgencia(string nombreAgencia)
        {
            //var dataAgenciaPath = HostingEnvironment.MapPath(_configuration["jwt:key"]);
            List<AgenciaDto> vl = new List<AgenciaDto>();
            return vl;
        }
    }
}
