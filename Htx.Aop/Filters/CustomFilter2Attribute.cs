using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Filters
{
    public class CustomFilter2: IActionFilter, IFilterMetadata
    {
        private readonly ILogger<CustomFilter2> _logger;
        public CustomFilter2(ILogger<CustomFilter2> logger)
        {
            this._logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"离开过滤器CustomFilter2：{context.HttpContext.Request.Path}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"进入过滤器CustomFilter2：{context.HttpContext.Request.Path}");
        }
    }
}
