using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRhetosHomePage(this IApplicationBuilder app, string route = null)
        {
            if (string.IsNullOrEmpty(route))
                route = "/rhetos/home";

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute("RhetosHomePage", route, new {controller = "RhetosHomePage", action = "Index"}));
            
            return app;
        }
    }
}
