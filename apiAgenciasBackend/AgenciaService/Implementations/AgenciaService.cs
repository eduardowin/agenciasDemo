using AgenciaRepository.Interfaces;
using AgenciasCrossCutting.Dto.Agencias;
using AgenciaService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaService.Implementations
{
    public class AgenciasService : IAgenciaService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AgenciasService(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this._configuration = configuration;
            _hostingEnvironment = hostingEnvironment;   
        }
        public async Task<List<AgenciaDto>> GetAgencia(string nombreAgencia)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var vListDataReniec = new List<AgenciaDto>();
            using (var reader = new StreamReader(contentRootPath + @"\Data\agencias.json"))
            {
                var json = reader.ReadToEnd();
                vListDataReniec = JsonConvert.DeserializeObject<List<AgenciaDto>>(json);
            }

            return vListDataReniec.FindAll(x => x.agencia.Contains(nombreAgencia));
        }
    }
}
