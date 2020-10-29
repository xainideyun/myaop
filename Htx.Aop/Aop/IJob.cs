using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Htx.Aop.Aop
{
    [Intercept(typeof(JobInterceptor))]
    public interface IJob
    {
        string Say(string msg);

        string Show(string msg);
    }
}
