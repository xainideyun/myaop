using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Aop2
{
    public class JobRepository : IJobRepository
    {
        private readonly ILogger<JobRepository> _logger;
        public JobRepository(ILogger<JobRepository> logger)
        {
            this._logger = logger;
        }

        public virtual string SayJob(string jobName)
        {
            var str = $"我的工作是：{jobName}";
            _logger.LogInformation(str);
            return str;
        }
    }
}
