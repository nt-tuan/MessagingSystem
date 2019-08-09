using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Web.ApiModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Middleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILoggerFactory _logger;
        
        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            } catch(Exception e)
            {
                ILogger log = _logger.CreateLogger("Exception");
                log.LogError(e.Message);
                await HandleExceptionAsync(httpContext, e);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception e)
        {

            context.Response.ContentType = "application/json";
            if(e is RepositoryException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                
                return context.Response.WriteAsync(ResponseModel.CreateError(e.Message).ToString());
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync("Internal Server Error.");
            }
        }
    }
}
