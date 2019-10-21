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
        private static readonly Step[] Steps = new[]
        {
            new Step{ StepId = 1, Name = "Step 1", State = StepState.NotSet },
            new Step{ StepId = 2, Name = "Step 2", State = StepState.NotSet },
            new Step{ StepId = 3, Name = "Step 3", State = StepState.NotSet },
            new Step{ StepId = 4, Name = "Step 4", State = StepState.NotSet },
            new Step{ StepId = 5, Name = "Step 5", State = StepState.NotSet },            
        };

        private readonly ILogger<StepController> logger;

        public StepController(ILogger<StepController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Step> Get()
        {
            return Steps;
        }
    }
}
