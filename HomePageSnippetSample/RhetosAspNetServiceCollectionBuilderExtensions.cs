using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhetos.Host.AspNet;
using Rhetos.Host.AspNet.HomePage;

namespace HomePageSnippetSample
{
    public static class RhetosAspNetServiceCollectionBuilderExtensions
    {
        public static RhetosAspNetServiceCollectionBuilder AddSampleSnippets(this RhetosAspNetServiceCollectionBuilder rhetosBuilder)
        {
            rhetosBuilder.AddHomePage(typeof(DemoComponent));
            rhetosBuilder.AddHomePage(typeof(DemoComponent2));
            return rhetosBuilder;
        }
    }
}
