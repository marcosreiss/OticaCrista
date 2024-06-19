using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class GetAllBrandsPaginadedUseCase(IBrandRepository _repository)
    {
        public async Task<PagedResponse<List<BrandModel>>> Execute(int skip, int take=10)
        {
            try
            {
                var brands = await _repository.GetAllBrandsPaginadedAsync(skip, take);
                var count = await _repository.CountBrandsAsync();
                var currentPage = (int)(skip / (double)take) + 1;
                return new PagedResponse<List<BrandModel>>(brands, count, currentPage, take, 200, "Success!");
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<BrandModel>>(null, 0, 0, 0, 500, ex.Message);
            }
        }

        
    }
}
