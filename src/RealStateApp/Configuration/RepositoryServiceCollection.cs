using RealStateApp.Domain.Entities;
using RealStateApp.Persistence.Repositories;

namespace RealStateApp.Configuration
{
    public static class RepositoryServiceCollection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<PropertyType>, Repository<PropertyType>>();
            services.AddScoped<IRepository<CondominiumType>, Repository<CondominiumType>>();
            return services;
        }
    }
}
