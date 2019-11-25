using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AgenciasCrossCutting.Helpers;
using AgenciasCrossCutting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace apiAgenciasBackend.Filters
{
    public class FilterException : ExceptionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        public FilterException(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {

                message = "Access to the Web API is not authorized.";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(DivideByZeroException))
            {
                message = "Internal Server Error. Msg: "+ JsonConvert.SerializeObject(context.Exception); 
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = "Internal Server Error. Msg: " + JsonConvert.SerializeObject(context.Exception);
                status = HttpStatusCode.InternalServerError;
            }

            var oResponseErrorDto = new ResponseErrorDto
            {
                Message = message,
                Type = exceptionType.ToString(),
            };
            var oCcResponseHelper = new ResponseHelper();
            context.Result = new ObjectResult(oCcResponseHelper.GenerarResponse500(oResponseErrorDto));

            base.OnException(context);
        }
    }
}
