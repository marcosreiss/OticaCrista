using SistOtica.Models.Service;

namespace OticaCrista.Infra.DataBase.Repository.Service
{
    public interface IServiceRepository
    {
        Task<ServiceModel?> CreateServiceAsync(ServiceModel service);
        Task<ServiceModel?> UpdateServiceAsync(int id, ServiceModel model);
        Task<ServiceModel?> DeleteServiceAsync(int id);
        Task<ServiceModel?> GetServiceByIdAsync(int id);
        Task<List<ServiceModel>?> GetAllServicesPaginadedAsync(int skip, int take);
        Task<int> CountServiceAsync();

    }
}
