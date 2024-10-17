using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ambev.Data.Interfaces;
using Ambev.Data.Repositories;
using Npgsql;
using System.Data.Common;
using Ambev.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ambev.IOC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<DbConnection>(sp => new NpgsqlConnection(config.GetConnectionString("pgsql")));

            services.AddDbContext<ApplicationDbContext>(
                    o => o.UseNpgsql(config.GetConnectionString("pgsql"),
                    p => p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IVendaRepository, VendaRepository>();

            return services;
        }
    }
}
