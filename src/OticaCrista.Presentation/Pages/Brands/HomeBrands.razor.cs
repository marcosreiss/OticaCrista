using Microsoft.AspNetCore.Components;
using SistOtica.Models.Product;
using RestSharp;
using OticaCrista.communication.Responses;
using MudBlazor;

namespace OticaCrista.Presentation.Pages.Brands
{
    public partial class HomeBrandsPage : ComponentBase
    {
        #region Props

        public List<BrandModel> Brands { get; set; } = new();
        public bool IsCreateModalVisible { get; set; } = false;

        #endregion

        #region Services

        [Inject] public IDialogService dialogService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        protected async override Task OnInitializedAsync()
        {
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand?currentPage=1");
            var response = await client.GetAsync<Response<List<BrandModel>>>( request );
            Brands = response?.Data ?? new();
        }

        public async Task OnCreateClickAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var createBrandDialog = dialogService.Show<CreateBrandModal>("Nova Marca", options);
            var result = await createBrandDialog.Result;
            if(!result.Canceled)
            {
                Brands.Add((BrandModel)result.Data);
                StateHasChanged();
            }
        }

        public async Task OnDeleteClickAsync(int id, string title)
        {
            var result = await dialogService.ShowMessageBox("Atenção",
                $"Deseja Excluir a Marca {title}?",
                yesText: "Excluir",
                cancelText: "Cancelar");
            if(result is true)
            {
                await DeleteBrandAsync(id);
                StateHasChanged();
            }
        }

        public async Task DeleteBrandAsync(int id)
        {
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand/{id}");
            var response = await client.DeleteAsync<Response<BrandModel>>( request );
            if (response.IsSuccess)
            {
                Brands.RemoveAll(b => b.Id == id);
                Snackbar.Add("Marca Deletada com Sucesso!", Severity.Success);
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }

        #endregion  
    }
}
