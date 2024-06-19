using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class CreateBrandUseCase(IBrandRepository _repository)
    {

        public async Task<Response<BrandModel>> Execute(BrandRequest request)
        {
            //Validate(request);
            var newBrand = new BrandModel
            {
                Name = request.Name,
                Products = null
            };
            var response = await _repository.CreateBrandAsync(newBrand);
            return new Response<BrandModel>(response, 200, "Success");
        }

        //private async void Validate(BrandRequest request)
        //{
        //    if (request.Name == null)
        //    {
        //        throw new ArgumentNullException(nameof(request));
        //    }
        //    var brands = await _repository.GetAllBrandsPaginaded();
        //    foreach (var brand in brands)
        //    {
        //        if (brand.Name == request.Name)
        //        {
        //            throw new InvalidOperationException("This Brand Already exists");
        //        }
        //    }
        //}
    }
}
