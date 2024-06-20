using Microsoft.AspNetCore.Components;
using SistOtica.Models.Product;
using RestSharp;
using OticaCrista.communication.Responses;


namespace OticaCrista.Presentation.Pages.Brands
{
    public partial class HomeBrandsPage : ComponentBase
    {
        public List<BrandModel> Brands { get; set; } = new();
        public bool IsModalVisible { get; set; } = false;

        

        protected async override Task OnInitializedAsync()
        {
            var client = new RestClient();
            var request = new RestRequest($"{Configuration.apiUrl}/product/brand?currentPage=1");
            var response = await client.GetAsync<Response<List<BrandModel>>>( request );
            Brands = response?.Data ?? new();
        }
    }
}
