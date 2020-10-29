using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this._logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
            //context.ExceptionHandled = true;
        }
    }
}
