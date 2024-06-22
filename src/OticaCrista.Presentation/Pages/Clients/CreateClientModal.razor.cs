using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Client;
using System.Text.Json;

namespace OticaCrista.Presentation.Pages.Clients
{
    public partial class CreateClientModalPage : ComponentBase
    {
        #region Props

        public ClientRequest input { get; set; } = new();
        public DateTime? BornDate { get; set; } = new(2001, 08, 16);
        public bool IsBusy = false;

        [CascadingParameter]
        public MudDialogInstance ModalInstance { get; set; } = null!;

        public MudForm CreateForm { get; set; } = null!;
        public bool Success { get; set; }
        public string[] ErrorMessages { get; set; } = { };

        #endregion

        #region Services

        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnSubmitAsync()
        {
            await CreateForm.Validate();
            if (Success)
            {
                await OnValidSubmitAsync();
            }
            else
            {
                for (int i = 0; i < ErrorMessages.Length; i++)
                {
                    Snackbar.Add(ErrorMessages[i], Severity.Error);
                }
            }
        }

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            input.BornDate = DateOnly.FromDateTime((DateTime)BornDate);

            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/client", Method.Post);
            request.AddJsonBody(input);
            try
            {
                var response = await client.PostAsync<Response<ClientModel>>(request);
                if (response.IsSuccess)
                {
                    IsBusy = false;
                    ModalInstance.Close(DialogResult.Ok<ClientModel>(response.Data));
                    Snackbar.Add(
                        $"Cliente \"{response.Data.Name}\" Cadastrada com sucesso!",
                        Severity.Success);
                }
            } catch (Exception ex)
            {
                Snackbar.Add("Erro: " + ex.Message, Severity.Error);
                IsBusy = false;
            }
        }

        public void Cancel() => ModalInstance.Close();

        #endregion
    }
}
