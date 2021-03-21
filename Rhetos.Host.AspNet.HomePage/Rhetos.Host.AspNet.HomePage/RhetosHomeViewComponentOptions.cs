using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rhetos.Host.AspNet.HomePage
{
    public class RhetosHomeViewComponentOptions
    {
        public List<Type> HomeViewComponents {get; set; } = new List<Type>();
    }
}
