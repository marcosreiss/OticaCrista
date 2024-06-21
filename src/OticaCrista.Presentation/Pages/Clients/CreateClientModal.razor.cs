using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Client;
using SistOtica.Models.Product;

namespace OticaCrista.Presentation.Pages.Clients
{
    public partial class CreateClientModalPage : ComponentBase
    {
        #region Props

        public ClientRequest input { get; set; } = new();

        public bool IsBusy = false;

        [CascadingParameter]
        public MudDialogInstance ModalInstance { get; set; } = null!;

        #endregion

        #region Services

        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/client", Method.Post);
            request.AddJsonBody(input);
            var response = await client.PostAsync<Response<ClientModel>>(request);
            if (response.IsSuccess)
            {
                IsBusy = false;
                ModalInstance.Close(DialogResult.Ok<ClientModel>(response.Data));
                Snackbar.Add(
                    $"Cliente \"{response.Data.Name}\" Cadastrada com sucesso!",
                    Severity.Success);
            }
        }

        public void Cancel() => ModalInstance.Close();

        #endregion
    }
}
