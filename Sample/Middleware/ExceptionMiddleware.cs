using Microsoft.AspNetCore.Http;
using Sample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Sample.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDeligate;

        public ExceptionMiddleware(RequestDelegate requestDeligate)
        {
            _requestDeligate = requestDeligate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDeligate(httpContext);
            }
            catch (Exception ex)
            {                
                //TODO: log
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //TODO: return user firendly exception
            return context.Response.WriteAsync("");
        }
    }
}
