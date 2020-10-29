using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Htx.Aop.Middlewares
{
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }

    public class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string msg;
            int statusCode;
            try
            {
                await _next(context);
                if (context.Response.StatusCode == 404)
                {
                    msg = $"【{context.Request.Path}】路径没有找到";
                    statusCode = 404;
                    context.Response.StatusCode = 200;
                    WriteToResponseAsync();
                }
            }
            catch (Exception ex)
            {
                msg = $"系统异常：{ex.Message}";
                statusCode = 500;
                WriteToResponseAsync();
            }


            void WriteToResponseAsync()
            {
                var result = new { result = false, message = msg, code = statusCode };
                context.Response.ContentType = "application/json;charset=utf8";
                var body = JsonConvert.SerializeObject(result);
                _logger.LogInformation($"返回结果：{body}");
                context.Response.WriteAsync(body);
            }

        }

    }
}
