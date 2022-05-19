using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using NLog;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsAPI.Middlewares.GlobalLogging
{
    public class GlobalLogMiddleware
    {
        private readonly RequestDelegate _next;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public GlobalLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sessionId = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
            context.Request.Headers.Add("SessionID", sessionId);

            var requestMessage = await FormatRequest(context.Request);
            var requestInfo = string.Format("{0} {1}", context.Request.Method, context.Request.GetDisplayUrl());

            var originalBodyStream = context.Response.Body;

            await Log("REQUEST", sessionId, requestInfo, requestMessage);

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);

                await Log("RESPONSE", sessionId, requestInfo, response);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            request.Body = body;

            if (bodyAsText == "")
            {
                bodyAsText = "(No body present)";
            }

            return bodyAsText;
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            string text = await new StreamReader(response.Body).ReadToEndAsync();

            if (text == "")
            {
                text = "(No body present)";
            }

            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {text}";
        }

        private async Task Log(string message, string sessionId, string requestInfo, string body)
        {
            await Task.Run(() =>
            {
                logger.Info(string.Format("SessionID: {0} | {1}: {2} | Body: {3}", sessionId, message, requestInfo, body));
            });
        }
    }
}
