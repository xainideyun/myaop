using Autofac.Extras.DynamicProxy;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Htx.Aop.Aop
{
    public class StandandJob : IJob
    {
        private readonly ILogger<StandandJob> _logger;
        public StandandJob(ILogger<StandandJob> logger)
        {
            _logger = logger;
        }
        public string Say(string msg)
        {
            var str = $"我跟你将：{msg}";
            _logger.LogInformation(str);
            return str;
        }

        public virtual string Show(string msg)
        {
            return msg;
        }
    }
}
