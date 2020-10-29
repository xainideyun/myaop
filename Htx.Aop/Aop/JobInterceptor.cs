using Castle.Core.Logging;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Aop
{
    public class JobInterceptor : IInterceptor
    {
        private readonly ILogger<JobInterceptor> _logger;
        public JobInterceptor(ILogger<JobInterceptor> logger)
        {
            this._logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            var args = string.Join(',', invocation.Arguments.Select(a => a.ToString()).ToArray());
            _logger.LogInformation($"JobInterceptor拦截器执行前，参数：{args}...");
            invocation.Proceed();
            _logger.LogInformation($"JobInterceptor拦截器执行之后，参数：{args}...");
        }
    }
}
