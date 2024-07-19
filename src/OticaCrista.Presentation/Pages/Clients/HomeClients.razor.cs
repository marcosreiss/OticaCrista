using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Responses;
using OticaCrista.Presentation.Pages.Brands;
using OticaCrista.Presentation.Pages.Products;
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
                {"clientModel",  client},
                { "ReadOnly", false }
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

        public void OnDetailsClick(ClientModel client)
        {
            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, FullWidth = true };
            var parameters = new DialogParameters
            {
                {"clientModel",  client},
                { "ReadOnly", true }
            };
            DialogService.Show<EditClientModal>("Detalhes do Cliente", parameters, options);
        }

        public async Task OnDeleteClieckAsync(int id, string name)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Tem certeza que deseja excluir o cliente {name}?",
                yesText: "Excluir",
                noText: "Cancelar");
            if ((bool)result)
            {
                var client = new RestClient();
                var request = new RestRequest($"{Configuration.apiUrl}/client/{id}", Method.Delete);
                var response = await client.DeleteAsync<Response<ClientModel>>(request);
                if(response.IsSuccess)
                {
                    Snackbar.Add($"Cliente {response.Data.Name} Deletado com sucesso!", Severity.Success);
                    Clients.RemoveAll(t => t.client.Id == id);
                    var clients = Clients.Select(t => t.client).ToList();
                    SortList(clients);
                }
            }
        }

        #endregion
    }
}
