using Microsoft.AspNetCore.Components;
using MudBlazor;
using RealStateApp.Application.ViewModels;
using RealStateApp.Components.Forms;
using RealStateApp.Shared.Components;

namespace RealStateApp.Pages
{
    public partial class CondominiumTypePage
    {
        [Inject]
        public CondominiumTypeViewModel ViewModel { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }

        [Inject]
        private IDialogService _dialogService { get; set; }

        private string searchString = "";

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.GetAllAsync();
        }

        private async Task NewCondominiumType()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions() { CloseButton = true, FullWidth = true };
            var dialog = await _dialogService.ShowAsync<CondominiumTypeForm>("Cadastrar Tipo de Condomínio ", parameters, options);
            await dialog.Result;
            await ViewModel.GetAllAsync();
        }

        private async Task EditCondominiumType(int id)
        {
            var parameters = new DialogParameters();
            parameters.Add("CondominiumTypeId", id);
            var options = new DialogOptions() { CloseButton = true, FullWidth = true };
            var dialog = await _dialogService.ShowAsync<CondominiumTypeForm>("Editar Tipo de Condomínio ", parameters, options);
            await dialog.Result;
            await ViewModel.GetAllAsync();
        }

        private async Task DeleteCondominiumType(int id)
        {
            var parameters = new DialogParameters<BaseDialog>
            {
                { x => x.ContentText, "Tem certeza que deseja deletar este tipo de condomínio?" },
                { x => x.ButtonText, "Deletar" },
                { x => x.Color, Color.Error }
            };

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = await _dialogService.ShowAsync<BaseDialog>("Atenção", parameters, options);
            var response = await dialog.Result;

            if (!response.Canceled)
            {
                var deleteResponse = await ViewModel.DeleteAsync(id);

                if (deleteResponse)
                {
                    _snackbar.Add("Tipo de condomínio deletado com sucesso", MudBlazor.Severity.Success, config =>
                    {
                        config.SnackbarVariant = Variant.Outlined;
                        config.IconSize = Size.Medium;
                        config.HideTransitionDuration = 100;
                        config.ShowTransitionDuration = 100;
                    });
                }
            }
        }
    }
}
