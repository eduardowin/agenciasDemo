using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciasCrossCutting.Response
{
    public class ResponseDto
    {
        public string ResStatus { get; set; }
        public List<ResponseErrorDto> ResError { get; set; }
        public object ResResult { get; set; }
    }
}
