using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddServices();

            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(e =>
                    e.IsClass
                    && !e.IsAbstract
                    && e.GetInterfaces().Contains(typeof(IBaseService)))
                .ToList()
                .ForEach(type =>
                {
                    var nestedInterface = type.GetInterfaces().First(x => x.GetInterfaces().Contains(typeof(IBaseService)));
                    services.AddScoped(nestedInterface, type);
                });
            return services;
        }
    }
}
