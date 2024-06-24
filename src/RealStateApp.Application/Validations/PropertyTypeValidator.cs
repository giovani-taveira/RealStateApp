using FluentValidation;
using RealStateApp.Application.ViewModels;

namespace RealStateApp.Application.Validations
{
    public class PropertyTypeValidator : AbstractValidator<PropertyTypeViewModel>
    {
        public PropertyTypeValidator()
        {
            RuleFor(pt => pt.CurrentPropertyType.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode ter mais de 100 caracteres.");
        }
    }
}
