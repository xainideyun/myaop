using Autofac.Extras.DynamicProxy;
using Htx.Aop.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Aop2
{
    [Intercept(typeof(JobInterceptor))]
    public interface IJobRepository
    {
        string SayJob(string jobName);
    }
}
