using Devspaces.Support;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC
{
    public static class ServiceCollectionDevspacesExtensions
    {
        public static IServiceCollection AddDevspaces(this IServiceCollection services)
        {
            services.AddTransient<DevspacesMessageHandler>();
            return services;
        }
    }
}
