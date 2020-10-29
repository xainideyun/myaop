using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Filters
{
    public class CustomFilter : IActionFilter
    {
        private readonly ILogger<CustomFilter> _logger;
        public CustomFilter(ILogger<CustomFilter> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"离开action：{context.HttpContext.Request.Path}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"进入action：{context.HttpContext.Request.Path}");
        }
    }
}
