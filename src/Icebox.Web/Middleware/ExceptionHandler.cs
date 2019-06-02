/*
 * Ty: Andrei @https://stackoverflow.com/a/38935583/6637951
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace Icebox.Web.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode code = _mapExceptionToCode(ex);

            string result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        private static HttpStatusCode _mapExceptionToCode(Exception ex)
        {
            return HttpStatusCode.InternalServerError;
        }
    }
}
