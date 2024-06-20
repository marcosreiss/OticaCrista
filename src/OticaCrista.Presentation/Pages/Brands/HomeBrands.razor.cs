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

        [Inject]
        public IDialogService dialogService { get; set; } = null!;

        #endregion

        #region Methods

        protected async override Task OnInitializedAsync()
        {
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand?currentPage=1");
            var response = await client.GetAsync<Response<List<BrandModel>>>( request );
            Brands = response?.Data ?? new();
        }

        public async void OpenModal()
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

        #endregion  
    }
}
