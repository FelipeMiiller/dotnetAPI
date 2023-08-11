

using System.Net;
using System.Text.Json;
using Api.Util.Error;

namespace Api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (AppException e)
            {
                var send = new
                {
                    Code = e.Code,
                    Title = e.Title,
                    Message = e.Message
                };

                var json = JsonSerializer.Serialize(send);
                
                context.Response.StatusCode = send.Code ;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
            


        }
    }
}