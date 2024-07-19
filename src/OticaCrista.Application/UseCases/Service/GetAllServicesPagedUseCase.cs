using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Service;
using SistOtica.Models.Service;

namespace OticaCrista.Application.UseCases.Service
{
    public class GetAllServicesPagedUseCase(IServiceRepository _repository)
    {
        public async Task<PagedResponse<List<ServiceModel>>> Execute(int skip = 0, int take = 3)
        {
            try
            {
                var services = await _repository.GetAllServicesPaginadedAsync(skip, take);
                var count = await _repository.CountServiceAsync();
                var currentPage = (int)(skip / (double)take) + 1;
                return new PagedResponse<List<ServiceModel>>(
                    services,
                    count,
                    currentPage,
                    take,
                    200,
                    "Serviços recuperados com sucesso!");
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<ServiceModel>>(null, 0, 0, 0, 500, ex.Message);
            }
        }

    }
}
