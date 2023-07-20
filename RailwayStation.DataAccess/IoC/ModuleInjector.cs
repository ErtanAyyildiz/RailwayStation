using Microsoft.Extensions.DependencyInjection;
using RailwayStation.DataAccess.Repositories.IRepositories;
using RailwayStation.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.DataAccess.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }
}
