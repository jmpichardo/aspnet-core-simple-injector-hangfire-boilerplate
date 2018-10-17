using ASPNetCoreHangfire.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace ASPNetCoreHangfire.SimpleInjector
{
    public static class IoCContainerFactory
    {
        public static void IntegrateSimpleInjector(this IServiceCollection services, Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public static void InitializeContainer(this IApplicationBuilder app, Container container, IConfiguration config)
        {
            MapInterfaces(container, config);

            container.Verify();
        }

        private static void MapInterfaces(Container container, IConfiguration config)
        {
            container.RegisterInstance(config);

            container.Register<IUsersService, UsersService>(Lifestyle.Transient);
        }
    }
}
