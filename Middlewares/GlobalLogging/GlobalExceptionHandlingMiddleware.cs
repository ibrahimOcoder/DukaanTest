using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using ProductsAPI.Modules;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProductsAPI.Middlewares.GlobalLogging
{
    public class GlobalExceptionHandlingMiddleware
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await Task.Run(() =>
                {
                    logger.Info(string.Format("SessionID: {0} | Exception {1}", context.Request.Headers["SessionID"], ex));
                });

                await HandleExceptionMessageAsync(context, ex);
            }
        }

        private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            ErrorModel errorModel = new ErrorModel();
            errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();
            errorModel.ErrorMessage = "Internal Server Error";

            var result = JsonConvert.SerializeObject(errorModel);

            return context.Response.WriteAsync(result);
        }
    }
}
