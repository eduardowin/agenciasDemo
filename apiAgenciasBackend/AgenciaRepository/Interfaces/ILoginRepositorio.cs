using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaRepository.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia);

    }
}
