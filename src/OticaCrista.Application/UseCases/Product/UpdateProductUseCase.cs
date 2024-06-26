using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class UpdateProductUseCase(IProductRepository _repository)
    {
        public async Task<Response<ProductModel>> Execute(ProductRequest request, int id)
        {
            try
            {
                var response = await _repository.UpdateProductAsync(request, id);
                if (response != null)
                {
                    return new Response<ProductModel>(response, 200, "Produto Atualizado com sucesso");
                }
                else
                {
                    return new Response<ProductModel>(null, 500, "erro ao atualizar produto");
                }
            }
            catch (Exception ex)
            {
                return new Response<ProductModel>(null, 500, "erro ao atualizar produto: " + ex.Message);
            }
        }
    }
}
