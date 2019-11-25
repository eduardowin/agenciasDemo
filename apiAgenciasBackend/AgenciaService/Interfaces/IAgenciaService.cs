using AgenciasCrossCutting.Dto.Agencias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaService.Interfaces
{
    public interface IAgenciaService
    {
        Task<List<AgenciaDto>> GetAgencia(string nombreAgencia);
    }
}
