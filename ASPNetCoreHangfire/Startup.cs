using ASPNetCoreHangfire.SimpleInjector;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace ASPNetCoreHangfire
{
    public class Startup
    {
        private IConfiguration Configuration;

        private readonly Container Container = new Container();

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DatabaseContext");

            var simpleInjector = new SimpleInjectorJobActivator(Container);

            services.AddHangfire(config => config.UseSqlServerStorage(connectionString)
                                                 .UseActivator(simpleInjector)
                                                 .UseFilter(new SimpleInjectorAsyncScopeFilterAttribute(Container)));

            services.IntegrateSimpleInjector(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Dependency injection for hangfire
            app.InitializeContainer(Container, Configuration);

            // Initialize hangfire
            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire");
        }
    }
}
