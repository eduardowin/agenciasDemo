using AgenciaRepository.Interfaces;
using AgenciaService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaService.Implementations
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepositorio _iRepositorio;
        public LoginService(ILoginRepositorio pIRepositorio)
        {
            this._iRepositorio = pIRepositorio;
        }
        public async Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia)
        {
            return await _iRepositorio.GetLogin(pUsuarioId, pContrasenia);
        }
    }
}
