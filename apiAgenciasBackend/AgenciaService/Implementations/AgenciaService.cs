using AgenciaRepository.Interfaces;
using AgenciasCrossCutting.Dto.Agencias;
using AgenciaService.Interfaces;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
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
            var JSON = System.IO.File.ReadAllText(contentRootPath + "/Data/companyInfo.json");


            var client = new RestClient("https://raw.githubusercontent.com/eduardowin/agenciasDemo/master/apiAgenciasBackend/apiAgenciasBackend/Data/agencias.js");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "raw.githubusercontent.com");
            request.AddHeader("Postman-Token", "0bdd43ec-998d-43b7-8450-be7d6c3bfeeb,5f367f05-1285-4210-b744-1fde0fc0b843");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            IRestResponse response = client.Execute(request);
            var ddd = JObject.Parse(response.Content);
            var lsitado = JsonConvert.DeserializeObject<List<AgenciaDto>>(response.Content);
            List<AgenciaDto> vl = new List<AgenciaDto>();
            return vl;
        }
    }
}
