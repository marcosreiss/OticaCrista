using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class GetAllProductsPagedUseCase(IProductRepository _repository)
    {
        public async Task<PagedResponse<List<ProductModel>>> Execute(int skip, int take)
        {
            try
            {
                var response = await _repository.GetAllProductsPaginadedAsync(skip, take);
                var count = await _repository.GetProductsCountAsync();
                var currentPage = (int)(skip / (double)take) + 1;
                if (response != null)
                {
                    return new PagedResponse<List<ProductModel>>(
                        response,
                        count,
                        currentPage,
                        take, 200,
                        "Produtos Recuperados com sucesso!");
                }
                else return new PagedResponse<List<ProductModel>>(null, 0, 0, 0, 500, "Erro ao recuperar produtos");
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<ProductModel>>(null, 0, 0, 0, 500, "Erro ao recuperar produtos: " + ex.Message);
            }
        }
    }
}
