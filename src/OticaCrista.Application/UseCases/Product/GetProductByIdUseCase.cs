using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class GetProductByIdUseCase(IProductRepository _repository)
    {
        public async Task<Response<ProductModel>> Execute(int id)
        {
            try
            {
                var response = await _repository.GetProductByIdAsync(id);
                if (response != null)
                {
                    return new Response<ProductModel>(response, 200, "Produto Recuperado com Sucesso");
                }
                else { return new Response<ProductModel>(null, 500, "Produto não encontrado"); }
            }
            catch (Exception ex)
            {
                return new Response<ProductModel>(null, 500, "erro ao Recuperar Produto: " + ex.Message);
            }
        }
    }
}
