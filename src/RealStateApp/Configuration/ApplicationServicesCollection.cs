using RealStateApp.Application.Services;
using RealStateApp.Application.Services.Interfaces;

namespace RealStateApp.Configuration
{
    public static class ApplicationServicesCollection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPropertyTypeService, PropertyTypeService>();
            services.AddScoped<ICondominiumTypeService, CondominiumTypeService>();
        }
    }
}
