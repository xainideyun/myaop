using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Htx.Aop.Aop;
using Htx.Aop.Aop2;
using Htx.Aop.Filters;
using Htx.Aop.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Htx.Aop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                option.Filters.Add<GlobalExceptionFilter>();    // 增加全局异常过滤器
            });
            services.AddScoped<CustomFilter>();         // 注册过滤器
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<JobInterceptor>();

            builder.RegisterType<StandandJob>().As<IJob>().EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(a => a.IsClass && a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .EnableClassInterceptors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseGlobalExceptionHandler();
            //}
            app.UseGlobalExceptionHandler();        // 添加全局异常中间件

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
