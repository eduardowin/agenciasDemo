using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaService.Interfaces
{
    public interface ILoginService
    {
        Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia);
    }
}
