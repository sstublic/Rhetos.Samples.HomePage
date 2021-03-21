using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rhetos.Host.AspNet.HomePage;

namespace Rhetos.Host.AspNet
{
    public static class RhetosAspNetServiceCollectionBuilderExtensions
    {
        public static RhetosAspNetServiceCollectionBuilder AddHomePage(this RhetosAspNetServiceCollectionBuilder rhetosBuilder, Type homePageViewComponentSnippet = null)
        {
            rhetosBuilder.Services
                .AddControllersWithViews()
                .AddApplicationPart(typeof(RhetosHomePageController).Assembly);
            
            rhetosBuilder.Services.AddOptions();
            if (homePageViewComponentSnippet != null)
                rhetosBuilder.Services.Configure<RhetosHomeViewComponentOptions>(o => o.HomeViewComponents.Add(homePageViewComponentSnippet));

            return rhetosBuilder;
        }
    }
}
