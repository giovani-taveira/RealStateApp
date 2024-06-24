using Microsoft.AspNetCore.Components;
using MudBlazor;
using RealStateApp.Application.ViewModels;
using FluentValidation;

namespace RealStateApp.Components.Forms
{
    public partial class PropertyTypeForm
    {
        [Inject]
        public PropertyTypeViewModel ViewModel { get; set; }

        [Inject]
        IValidator<PropertyTypeViewModel> PropertyTypeValidator { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }

        [Parameter]
        public int? PropertyTypeId { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if(PropertyTypeId.HasValue)
            {
                await ViewModel.GetByIdAsync(PropertyTypeId.Value);
            }
            else
            {
                ViewModel.GetNewProperty();
            }
        }

        private async Task SubmitForm()
        {
            if (!await ValidateForm()) return;

            bool result = await ViewModel.SaveAsync();

            if (result)
            {
                _snackbar.Add("Dados salvos com sucesso", MudBlazor.Severity.Success, config =>
                {
                    config.SnackbarVariant = Variant.Outlined;
                    config.IconSize = Size.Medium;
                    config.HideTransitionDuration = 100;
                    config.ShowTransitionDuration = 100;
                });

                MudDialog.Close(DialogResult.Ok(true));
            }
            else
            {
                _snackbar.Add("Ocorreu um erro ao tentar salvar os dados", MudBlazor.Severity.Error, config =>
                {
                    config.SnackbarVariant = Variant.Outlined;
                    config.IconSize = Size.Medium;
                    config.HideTransitionDuration = 100;
                    config.ShowTransitionDuration = 100;
                });
            }
        }

        private async Task<bool> ValidateForm()
        { 
            var validationResult = await PropertyTypeValidator.ValidateAsync(ViewModel);

            if (validationResult.IsValid) return true;

            else
            {
                _snackbar.Add(validationResult.Errors.First().ErrorMessage, MudBlazor.Severity.Error, config =>
                {
                    config.SnackbarVariant = Variant.Outlined;
                    config.IconSize = Size.Medium;
                    config.HideTransitionDuration = 100;
                    config.ShowTransitionDuration = 100;
                });

                return false;             
            }
        }
    }
}
