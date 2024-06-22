using OticaCrista.communication.Requests.Product;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using RestSharp;
using OticaCrista.communication.Responses;
using SistOtica.Models.Product;
using MudBlazor;

namespace OticaCrista.Presentation.Pages.Brands
{
    public partial class CreateBrandModalPage : ComponentBase
    {
        #region Props

        public BrandRequest input = new();

        public bool IsBusy = false;

        [CascadingParameter]
        public MudDialogInstance ModalInstance { get; set; } = null!;

        public MudForm form {  get; set; }
        public bool success;
        public string[] errors = { };

        #endregion

        #region Services

        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnCreateClickedAsync()
        {
            await form.Validate();
            if (success)
            {
                await OnValidSubmitAsync();
            }
        }

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand", Method.Post);
            request.AddJsonBody(input);
            var response = await client.PostAsync<Response<BrandModel>>(request);
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
