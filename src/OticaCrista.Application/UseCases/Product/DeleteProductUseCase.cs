using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class DeleteProductUseCase(IProductRepository _repository)
    {


        public async Task<Response<ProductModel>> Execute(int id)
        {
            try
            {
                var response = await _repository.DeleteProductAsync(id);
                if (response != null)
                    return new Response<ProductModel>(response, 200, "Produto Deletado com Sucesso!");
                else
                    return new Response<ProductModel>(null, 500, "Erro ao Deletar Cliente");
            } 
            catch (Exception ex)
            {
                return new Response<ProductModel>(null, 500, "Erro ao Deletar Cliente" +  ex.Message);
            }
        }
    }
}
