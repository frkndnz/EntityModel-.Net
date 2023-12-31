
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next; 
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch=Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP "+ context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                
                await _next(context); // BİR SONRAKİ MİDDLAWARE ÇAĞIRILMA ŞEKLİ.   
                watch.Stop(); // response dönene kadar geçen süreyi hesapla.
                
                message="[Response] HTTP" + context.Request.Method + " - " +context.Request.Path + " responsed" + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds;
                _loggerService.Write(message);
                
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context,ex,watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType="application/json";
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

            string message="[ERROR]  HTTP" + context.Request.Method + " - " + context.Response.StatusCode + "Error Message : " + ex.Message + " in " + watch.ElapsedMilliseconds + "ms";
            _loggerService.Write(message);
            

            var result= JsonConvert.SerializeObject(new {error =ex.Message},Formatting.None); // json formatına dönüştürme işlemi.
            return context.Response.WriteAsync(result);
        }
    }
    
    public static class CustomExceptionMiddlewareExtension
    {
        
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}