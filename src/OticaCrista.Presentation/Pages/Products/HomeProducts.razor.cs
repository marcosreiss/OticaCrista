using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Product;

namespace OticaCrista.Presentation.Pages.Products
{
    public partial class HomeProductsPage : ComponentBase
    {
        #region Props

        public List<(ProductModel product, int position)> Products { get; set; } = new();
        public bool LoadingTable { get; set; } = false;

        #endregion

        #region Services

        [Inject] public IDialogService DialogService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        private void SortList(List<ProductModel> list)
        {
            if (Products.Count > 0)
            {
                Products.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Products.Add((list[i], i + 1));
            }
        }

        protected async override Task OnInitializedAsync()
        {
            LoadingTable = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product?currentPage=1");
            var response = await client.GetAsync<Response<List<ProductModel>>>(request);
            var list = response.Data;
            SortList(list);
            LoadingTable = false;
        }

        public async Task OnCreateClickAsync()
        {
            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, FullWidth = true };
            var dialog = DialogService.Show<CreateProductModal>("Novo Produto", options);
            var response = await dialog.Result;
            var product = response.Data as ProductModel;
            if (!response.Canceled && product != null)
            {
                Products.Add((product, Products.Count + 1));
            }
        }

        //public async Task OnEditClickAsync(ProductModel product, int position)
        //{
        //    var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, FullWidth = true };
        //    var parameters = new DialogParameters
        //{
        //    {"productModel", product},
        //    { "ReadOnly", false }
        //};
        //    var dialog = DialogService.Show<EditProductModal>("Editar Produto", parameters, options);
        //    var response = await dialog.Result;
        //    product = response.Data as ProductModel;

        //    if (!response.Canceled && product != null)
        //    {
        //        Products[position - 1] = (product, position);
        //        StateHasChanged();
        //    }
        //}

        //public void OnDetailsClick(ProductModel product)
        //{
        //    var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, FullWidth = true };
        //    var parameters = new DialogParameters
        //{
        //    {"productModel", product},
        //    { "ReadOnly", true }
        //};
        //    DialogService.Show<EditProductModal>("Detalhes do Produto", parameters, options);
        //}

        public async Task OnDeleteClickAsync(int id, string name)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Tem certeza que deseja excluir o produto {name}?",
                yesText: "Excluir",
                noText: "Cancelar");
            if ((bool)result)
            {
                var client = new RestClient();
                var request = new RestRequest($"{Configuration.apiUrl}/product/{id}", Method.Delete);
                var response = await client.DeleteAsync<Response<ProductModel>>(request);
                if (response.IsSuccess)
                {
                    Snackbar.Add($"Produto {response.Data.Name} Deletado com sucesso!", Severity.Success);
                    Products.RemoveAll(t => t.product.Id == id);
                    var products = Products.Select(t => t.product).ToList();
                    SortList(products);
                }
            }
        }

        #endregion
    }

}
