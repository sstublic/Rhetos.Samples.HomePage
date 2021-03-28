using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePageSnippetSample;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Rhetos;

namespace SampleWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleWebApp", Version = "v1" });
                c.SwaggerDoc("rhetos", new OpenApiInfo { Title = "rhetos", Version = "v1" });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                });

            services
                .AddRhetos(builder => ConfigureRhetosHostBuilder(builder, Configuration))
                .UseAspNetCoreIdentityUser()
                .AddRestApi(o => { })
                .AddImpersonation()
                .AddDashboard()
                .AddSampleSnippets();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleWebApp v1");
                    c.SwaggerEndpoint("/swagger/rhetos/swagger.json", "Rhetos");
                });
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRhetosDashboard();
            });
        }

        public static void ConfigureRhetosHostBuilder(IRhetosHostBuilder rhetosHostBuilder, IConfiguration configuration)
        {
            rhetosHostBuilder
                .ConfigureRhetosHostDefaults()
                .ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(configuration));
        }
    }
}
