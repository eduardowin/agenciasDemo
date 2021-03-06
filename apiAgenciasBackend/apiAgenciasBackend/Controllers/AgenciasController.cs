﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciasCrossCutting.Constantes;
using AgenciasCrossCutting.Dto.Agencias;
using AgenciasCrossCutting.Helpers;
using AgenciasCrossCutting.Response;
using AgenciaService.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace apiAgenciasBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly IAgenciaService  _iRolService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AgenciasController(IConfiguration configuration, IAgenciaService pIRolService, IMapper mapper)
        {
            this._iRolService = pIRolService;
            this._configuration = configuration;
            this._mapper = mapper;
        }
 
        [HttpGet("GetAgencias/{pCriterio}/{pNumeroDePagina}/{pCantidadDeRegistros}")]
        public async Task<ActionResult> GetAgencias(string pCriterio, int pNumeroDePagina = 1, int pCantidadDeRegistros = 10)
        {
            var oUsuarioHelper = new UsuarioHelper(_configuration);
            var oUsuarioDto = oUsuarioHelper.ObtenerUsuarioDeClaims(this.HttpContext);
            var agenciasDto = await _iRolService.GetAgencia(pCriterio );
            var AgenciaConsultaDto = _mapper.Map<List<AgenciaConsultaDto>>(agenciasDto).ToList();

            var oResponseConsultaDto = new ResponseConsultaDto<AgenciaConsultaDto>()
            {
                ResResult = AgenciaConsultaDto,
                ResStatus = Constantes.ResultadoSistema.Ok
            };

            return Ok(oResponseConsultaDto);
        }

    }
}