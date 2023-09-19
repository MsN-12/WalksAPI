﻿using System.Net;

namespace WalksAPI.MiddleWares
{
    public class ExeptionHandlerMiddleware
    {
        private readonly ILogger<ExeptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExeptionHandlerMiddleware(ILogger<ExeptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                logger.LogError(ex, $"{errorId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Somthing went wrong",
                };
                
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }


    }
}
