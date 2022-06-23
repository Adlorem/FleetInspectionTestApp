using FleetInspection.DataAccess.Factories;
using FleetInspection.DataAccess.Models;
using FleetInspection.DataAccess.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbAccessStores(this IServiceCollection services, Action<DbProviderModel> dbProviderOptionsAction = null)
        {
            var options = GetDefaultOptions();
            dbProviderOptionsAction?.Invoke(options);
            services.AddSingleton(options);
            services.AddScoped<IDefaultSqlConnectionFactory>(service => new DefaultSqlConnectionFactory(options.ConnectionString, options.DbSchema));
            services.AddScoped<IDataAccessFactory, DataAccessFactory>();
            services.AddScoped<IVehicleStore, VehicleStore>();
            services.AddScoped<IVehicleInspectionsStore, VehicleInspectionsStore>();

            return services;
        }

        public static DbProviderModel GetDefaultOptions()
        {
            return new DbProviderModel();
        }
    }
}
