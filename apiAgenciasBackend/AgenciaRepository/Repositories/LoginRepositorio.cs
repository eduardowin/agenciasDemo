using AgenciaRepository.Interfaces;
using AgenciasCrossCutting.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaRepository.Repositories
{
    public class LoginRepositorio: ILoginRepositorio
    {
        public async Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia)
        {
            var vContrasenia =  (pContrasenia);

            var oUsuarioAutentificado = new UsuarioAgenciaBe()
            {
                UsuarioId = pUsuarioId,
                NombreRol = "RolAdministrador",
                NombreUsu = "Usuario Administrador",
                RolId= "1",
                CorreoEletronico= "eduardowon@gmail.com"
            };

            return oUsuarioAutentificado;
        }

    }
}
