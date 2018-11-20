using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ClassLibrary
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddClassLibraryDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPrimaryInterface, PrimaryImplementation>();
            return services;
        }
    }
}
