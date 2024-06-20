using OticaCrista.communication.Requests.Product;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using RestSharp;
using OticaCrista.communication.Responses;
using SistOtica.Models.Product;

namespace OticaCrista.Presentation.Pages.Brands
{
    public partial class CreateBrandComponentPage : ComponentBase
    {
        public BrandRequest input = new();
        public bool IsBusy = false;

        [Inject]
        public NavigationManager navigationManager { get; set; } = null!;

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand", Method.Post);
            request.AddJsonBody(input);
            var response = await client.PostAsync<Response<BrandModel>>(request);
            if (response.IsSuccess)
            {
                navigationManager.NavigateTo("brands");
            }
            IsBusy = false;
        }
    }
}
