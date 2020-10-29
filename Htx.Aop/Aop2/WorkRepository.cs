using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Aop2
{
    public class WorkRepository: IWorkRepository
    {
        private readonly ILogger<WorkRepository> _logger;
        public WorkRepository(ILogger<WorkRepository> logger)
        {
            this._logger = logger;
        }

        public virtual string SayWork(string jobName)
        {
            var str = $"我正在干的活是：{jobName}";
            _logger.LogInformation(str);
            return str;
        }
    }
}
