using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Product;

namespace OticaCrista.Presentation.Pages.Brands
{
    public partial class UpdateBrandModalPage : ComponentBase
    {
        #region Props

        public BrandRequest input = new();
        public bool IsBusy = false;

        [CascadingParameter]
        public MudDialogInstance ModalInstance { get; set; } = null!;

        [Parameter] public BrandModel model { get; set; } = null!;

        #endregion

        #region Services

        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        protected async override Task OnInitializedAsync()
        {
            IsBusy = true;
            input.Name = model.Name;
            IsBusy = false;
        }

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand/{model.Id}", Method.Put);
            request.AddJsonBody(input);
            var response = await client.PutAsync<Response<BrandModel>>(request);
            if (response.IsSuccess)
            {
                IsBusy = false;
                ModalInstance.Close(DialogResult.Ok<BrandModel>(response.Data));
                Snackbar.Add(
                    $"Marca \"{response.Data.Name}\" Cadastrada com sucesso!",
                    Severity.Success);
            }
        }

        public void Cancel() => ModalInstance.Close();

        #endregion
    }
}
