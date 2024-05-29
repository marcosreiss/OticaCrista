using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class CreateClientUseCase
    {
        public async Task<ClientModel> Execute(RequestClientJson requestClientJson)
        {

        }

        private void Validate(RequestClientJson request)
        {
            var validator = new CreateClientValidator();
        }
    }
}
