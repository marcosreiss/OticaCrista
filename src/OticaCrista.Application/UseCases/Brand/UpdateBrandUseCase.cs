using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class UpdateBrandUseCase(IBrandRepository _repository)
    {
        public async Task<Response<BrandModel>> Execute(BrandRequest request, int id)
        {
            try
            {
                var newBrand = await _repository.UpdateBrandAsync(request, id);
                return new Response<BrandModel>(newBrand, 200, "Success");
            }
            catch (Exception ex)
            {
                return new Response<BrandModel>(null, 500, ex.Message);
            }

        }
    }
}
