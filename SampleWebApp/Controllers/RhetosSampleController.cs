using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhetos.Host.AspNet;
using Rhetos.Processing;

namespace SampleWebApp.Controllers
{
    [Route("/rhetossample")]
    public class RhetosSampleController : ControllerBase
    {
        private readonly IRhetosComponent<IProcessingEngine> processingEngine;
        public RhetosSampleController(IRhetosComponent<IProcessingEngine> processingEngine)
        {
            this.processingEngine = processingEngine;
        }

        [HttpGet]
        public string Get()
        {
            return processingEngine.Value.GetType().FullName;
        }
    }
}
