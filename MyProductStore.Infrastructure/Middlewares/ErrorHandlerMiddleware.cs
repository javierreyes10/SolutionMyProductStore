using Microsoft.AspNetCore.Http;
using MyProductStore.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyProductStore.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                var message = string.Empty;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ApiBusinessException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = e?.Message;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "There was an error with your request. Please try again later";
                        break;
                }

                var result = JsonConvert.SerializeObject(new { message = message });
                await response.WriteAsync(result);
            }


        }
    }
}
