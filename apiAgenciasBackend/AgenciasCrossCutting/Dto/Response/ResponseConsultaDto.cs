using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciasCrossCutting.Response
{
    public class ResponseConsultaDto<T>
    {
        public string ResStatus { get; set; }
        public int TotalRegistros { get; set; }
        public int CantidadPaginas { get; set; }
        public List<T> ResResult { get; set; }
    }
}
