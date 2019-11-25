using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciasCrossCutting.Dto.Agencias
{
    public class AgenciaDto
    {
        public string agencia { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string direccion { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }

    }
}
