using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciasCrossCutting.Constantes
{
    public static class Constantes
    {
        public static class UrlServiciosEs
        {
            public const string apiEsVetAcceso = "apiEsVetAcceso";
        }

        public static class ApiController
        {
            public const string LogErrores = "api/LogErrores";
        }
        public static class ResultadoSistema
        {
            public const string Ok = "Ok";
            public const string Error = "Error";
            public const string BadResquest = "BadResquest";
            public const string Advertencia = "Advertencia";
        }
        public static class EstadosRegistro
        {
            public const int Activo = 1;
            public const int Inactivo = 0;
        }
        public static class HeadersRequest
        {
            public const string RucCia = "RucCia";
        }
    }
}
