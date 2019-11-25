using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciasCrossCutting.Dto.Login
{
    public class UsuarioDto
    {
        public string UsuarioId { get; set; }
        public string NombreUsu { get; set; }
        public string CorreoEletronico { get; set; }
        public string RolId { get; set; }
        public string NombreRol { get; set; }
    }
}
