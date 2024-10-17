using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ambev.Data.Interfaces;
using Ambev.Data.Repositories;

namespace Ambev.IOC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<IVendaRepository, VendaRepository>();

            return services;
        }
    }
}
