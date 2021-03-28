using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rhetos.Host.AspNet;

namespace HomePageSnippetSample
{
    public static class RhetosAspNetServiceCollectionBuilderExtensions
    {
        public static RhetosAspNetServiceCollectionBuilder AddSampleSnippets(this RhetosAspNetServiceCollectionBuilder rhetosBuilder)
        {
            rhetosBuilder.AddDashboardSnippet(typeof(DemoComponent), "Demo");
            rhetosBuilder.AddDashboardSnippet(typeof(DemoComponent2), "Demo2");
            return rhetosBuilder;
        }
    }
}
