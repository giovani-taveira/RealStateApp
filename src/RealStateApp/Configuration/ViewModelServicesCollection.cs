using RealStateApp.Application.ViewModels;

namespace RealStateApp.Configuration
{
    public static class ViewModelServicesCollection
    {
        public static void AddViewModelServices(this IServiceCollection services)
        {
            services.AddScoped<PropertyTypeViewModel>();
            services.AddScoped<CondominiumTypeViewModel>();
        }
    }
}
