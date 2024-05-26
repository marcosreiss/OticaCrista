using OticaCrista.Infra.DataBase.Repository;

namespace OticaCrista.Application.UseCases.Product
{
    public class BrandUseCases
    {
        private readonly IBrandRepository _brandRepository;

        public BrandUseCases(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
    }
}
