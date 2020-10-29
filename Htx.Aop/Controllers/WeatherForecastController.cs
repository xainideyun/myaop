using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Htx.Aop.Aop;
using Htx.Aop.Aop2;
using Htx.Aop.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Htx.Aop.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new Exception("我出错了");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [CustomFilterFactory]
        [HttpGet("index")]
        public string Index()
        {
            return "哈哈";
        }

        [TypeFilter(typeof(CustomFilter2))]
        [HttpGet("index2")]
        public string Index2()
        {
            return "嘻嘻";
        }

        [HttpGet("index3")]
        public string Index3([FromServices]IJob job)
        {
            return job.Say("你好啊");
        }

        [HttpGet("index4")]
        public string Index4([FromServices] IJob job)
        {
            return job.Show("恍恍");
        }

        [HttpGet("index5")]
        public string Index5([FromServices] IJobRepository job)
        {
            return job.SayJob("程序员");
        }

        [HttpGet("index6")]
        public string Index6([FromServices] IWorkRepository work)
        {
            return work.SayWork("写代码");
        }

    }
}
