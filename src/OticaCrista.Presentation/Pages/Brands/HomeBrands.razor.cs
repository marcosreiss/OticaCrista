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

        public List<(BrandModel brand, int position)> Brands { get; set; } = new();
        public bool IsCreateModalVisible { get; set; } = false;

        #endregion

        #region Services

        [Inject] public IDialogService dialogService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        private void SortList(List<BrandModel> list)
        {
            if(Brands.Count > 0)
            {
                Brands.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Brands.Add((list[i], i + 1));
            }
        }

        protected async override Task OnInitializedAsync()
        {
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand?currentPage=1");
            var response = await client.GetAsync<Response<List<BrandModel>>>( request );
            var list = response.Data as List<BrandModel>;
            SortList( list );
        }

        public async Task OnCreateClickAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton=true };
            var createBrandDialog = dialogService.Show<CreateBrandModal>("Nova Marca", options);
            var result = await createBrandDialog.Result;
            var brand = result.Data as BrandModel;
            if(!result.Canceled)
            {
                var position = Brands.Count + 1;
                Brands.Add((brand, position));
                StateHasChanged();
            }
        }

        public async Task OnEditClickAsync(BrandModel brand, int brandPosition)
        {
            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true };
            var parameters = new DialogParameters
            {
                {"Model", brand }
            };

            var EditBrandModal = dialogService.Show<UpdateBrandModal>("Editar Marca", parameters, options);
            var result = await EditBrandModal.Result;
            var brandResponse = result.Data as BrandModel ?? new BrandModel();
            if(!result.Canceled)
            {
                Brands[brandPosition - 1] = (brandResponse, brandPosition);
            }
            StateHasChanged();
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
                Brands.RemoveAll(b => b.brand.Id == id);
                SortList(Brands.Select(x => x.brand).ToList());
                StateHasChanged();
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
