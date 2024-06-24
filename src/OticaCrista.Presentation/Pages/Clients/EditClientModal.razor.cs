using Microsoft.AspNetCore.Components;
using MudBlazor;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using RestSharp;
using SistOtica.Models.Client;

namespace OticaCrista.Presentation.Pages.Clients
{
    public partial class EditClientModal : ComponentBase
    {
        #region Props

        [Parameter]
        public ClientModel clientModel { get; set; } = null!;
        public ClientRequest request { get; set; } = new();

        public List<ContactJson> contacts { get; set; } = new();

        public List<ReferenceJson> references { get; set; } = new();
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

        protected async override Task OnInitializedAsync()
        {
            

            BornDate = DateTime.Parse(clientModel.BornDate.ToString());



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
            this.request.BornDate = DateOnly.FromDateTime((DateTime)BornDate);
            if (contacts[0].PhoneNumber != null)
            {
                this.request.Contacts = contacts;
            }
            if (references[0].Name != null)
            {
                this.request.References = references;
            }

            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/client/{clientModel.Id}", Method.Put);
            request.AddJsonBody(this.request);
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
