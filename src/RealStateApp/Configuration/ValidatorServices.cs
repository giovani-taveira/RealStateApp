using FluentValidation;
using RealStateApp.Application.Validations;
using RealStateApp.Application.ViewModels;

namespace RealStateApp.Configuration
{
    public static class ValidatorServices 
    {
        public static void AddValidatorServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PropertyTypeViewModel>, PropertyTypeValidator>();
            services.AddTransient<IValidator<CondominiumTypeViewModel>, CondominiumTypeValidator>();
        }
    }
}
