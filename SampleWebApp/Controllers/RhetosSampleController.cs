using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        [Route("/login")]
        [HttpGet]
        public async Task Login()
        {
            var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "SampleUser") }, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties() { IsPersistent = true });
        }
    }
}
