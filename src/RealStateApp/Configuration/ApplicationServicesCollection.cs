using RealStateApp.Application.Services;

namespace RealStateApp.Configuration
{
    public static class ApplicationServicesCollection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPropertyTypeService, PropertyTypeService>();
        }
    }
}
