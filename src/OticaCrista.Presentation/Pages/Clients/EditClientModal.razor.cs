using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Maps;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Client;
using System.Text.Json;

namespace OticaCrista.Presentation.Pages.Clients
{
    public partial class EditClientModalPage : ComponentBase
    {
        #region Props

        [Parameter]
        public ClientModel clientModel { get; set; } = null!;
        public ClientRequest input { get; set; } = new();

        public List<ContactJson> contacts { get; set; } = new();

        public List<ReferenceJson> references { get; set; } = new();
        public DateTime? BornDate { get; set; }

        public bool IsBusy = false;
        [Parameter]
        public bool ReadOnly {  get; set; }

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

        protected async override Task OnInitializedAsync()
        {
            input = ClientMap.ClientToRequest(clientModel);

            if (input.Contacts.Count > 0) contacts = input.Contacts;
            else AddContactField();

            if(input.References.Count > 0) references = input.References;
            else AddReferenceField();

            BornDate = DateTime.Parse(input.BornDate.ToString());
        }

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
            if (!string.IsNullOrWhiteSpace(contacts[0].PhoneNumber))
                input.Contacts = contacts;

            if (!string.IsNullOrWhiteSpace(references[0].Name))
                input.References = references;

            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/client/{clientModel.Id}", Method.Put);
            request.AddJsonBody(input);
            try
            {
                var response = await client.PutAsync<Response<ClientModel>>(request);
                if (response.IsSuccess)
                {
                    IsBusy = false;
                    ModalInstance.Close(DialogResult.Ok<ClientModel>(response.Data));
                    Snackbar.Add(
                        $"Cliente \"{response.Data.Name}\" Editado com sucesso!",
                        Severity.Success);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add("Erro: " + ex.Message, Severity.Error);
                IsBusy = false;
            }
        }

        public void Cancel() => ModalInstance.Close();
        public void AddContactField()
        {
            var contact = new ContactJson();
            contacts.Add(contact);
        }
        public void AddReferenceField()
        {
            var reference = new ReferenceJson();
            references.Add(reference);
        }

        #endregion
    }
}
