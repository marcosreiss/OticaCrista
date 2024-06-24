using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Client;
using SistOtica.Models.Product;

namespace OticaCrista.Presentation.Pages.Clients
{
    public partial class HomeClientsPage : ComponentBase
    {
        #region Props

        public List<(ClientModel client, int position)> Clients { get; set; } = [];
        public bool LoadingTable { get; set; } = false;

        #endregion

        #region Services

        [Inject] public IDialogService DialogService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        private void SortList(List<ClientModel> list)
        {
            if (Clients.Count > 0)
            {
                Clients.Clear();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Clients.Add((list[i], i + 1));
            }
        }

        protected async override Task OnInitializedAsync()
        {
            LoadingTable = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/client?currentPage=1");
            var response = await client.GetAsync<Response<List<ClientModel>>>(request);
            var list = response.Data;
            SortList(list);
            LoadingTable = false;
        }

        public async Task OnCreateClinckAsync()
        {
            var options = new DialogOptions { CloseButton=true, CloseOnEscapeKey=true, FullWidth=true };
            var dialog = DialogService.Show<CreateClientModal>("Novo Cliente", options);
            var response = await dialog.Result;
            var client = response.Data as ClientModel;
            if(!response.Canceled && client != null)
            {
                Clients.Add((client, Clients.Count));
            }
        }

        public async Task OnEditClieckAsync(ClientModel client, int position)
        {
            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, FullWidth = true };
            var parameters = new DialogParameters
            {
                {"clientModel",  client}
            };
            var dialog = DialogService.Show<EditClientModal>("Editar Cliente", parameters, options);
            var response = await dialog.Result;
            client = response.Data as ClientModel;

            if(!response.Canceled && client != null)
            {
                Clients[position-1] = (client, position);
                StateHasChanged();
            }

        }

        #endregion
    }
}
