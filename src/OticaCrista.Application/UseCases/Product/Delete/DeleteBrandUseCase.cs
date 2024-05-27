using OticaCrista.Infra.DataBase.Repository;

namespace OticaCrista.Application.UseCases.Product.Delete
{
    public class DeleteBrandUseCase
    {
        private readonly IBrandRepository _brandRepository;
        public DeleteBrandUseCase(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<bool> Execute(int id)
        {
            return await _brandRepository.Delete(id);
        }
    }
}
