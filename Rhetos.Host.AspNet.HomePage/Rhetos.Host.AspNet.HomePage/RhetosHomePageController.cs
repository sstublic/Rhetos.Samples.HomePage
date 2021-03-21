using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rhetos.Host.AspNet.HomePage
{
    public class RhetosHomePageController : Controller
    {
        public RhetosHomePageController()
        {
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }
    }
}
