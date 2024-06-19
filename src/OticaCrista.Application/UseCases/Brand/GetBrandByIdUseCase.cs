using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class GetBrandByIdUseCase(IBrandRepository _repository)
    {
        public async Task<Response<BrandModel>> Execute(int id)
        {
            try
            {
                var brand = await _repository.GetBrandByIdAsync(id);
                return new Response<BrandModel>(brand, 200, "Sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<BrandModel>(null, 500, ex.Message);
            }
        }
    }
}
