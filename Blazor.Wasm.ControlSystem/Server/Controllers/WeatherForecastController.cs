using Blazor.Wasm.ControlSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blazor.Wasm.ControlSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StepController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<StepController> logger;

        public StepController(ILogger<StepController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Step> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Step
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
