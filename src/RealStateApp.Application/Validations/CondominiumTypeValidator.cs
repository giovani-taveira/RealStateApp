using FluentValidation;
using RealStateApp.Application.ViewModels;

namespace RealStateApp.Application.Validations
{
    public class CondominiumTypeValidator : AbstractValidator<CondominiumTypeViewModel>
    {
        public CondominiumTypeValidator()
        {
            RuleFor(pt => pt.CurrentCondominiumType.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode ter mais de 100 caracteres.");
        }
    }
}
