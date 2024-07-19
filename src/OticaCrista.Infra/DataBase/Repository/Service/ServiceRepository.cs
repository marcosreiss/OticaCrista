using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistOtica.Models.Service;

namespace OticaCrista.Infra.DataBase.Repository.Service
{
    public class ServiceRepository(
        IDbContextFactory<OticaCristaContext> factory,
        ILogger<ServiceRepository> logger) 
        : IServiceRepository
    {
        private readonly OticaCristaContext context = factory.CreateDbContext();

        public async Task<ServiceModel?> CreateServiceAsync(ServiceModel service)
        {
            try
            {
                await context.Services.AddAsync(service);
                await context.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em ServiceRepository.CreateServiceAsync:\n" + ex.Message);
            }
            return null;
        }
        public async Task<ServiceModel?> UpdateServiceAsync(int id, ServiceModel model)
        {
            try
            {
                var service = await context.Services.FirstOrDefaultAsync(x => x.Id == id);

                if (service == null)
                {
                    logger.LogError("(ServiceRepository.UpdateServiceAsync): id pasado inválido, service não encontrada");
                    return null;
                }

                service.Name = model.Name;
                service.Price = model.Price;

                context.Services.Update(service);
                await context.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em ServiceRepository.UpdateServiceAsync:\n" + ex.Message);
            }
            return null;
        }
        public async Task<ServiceModel?> DeleteServiceAsync(int id)
        {
            try
            {
                var service = await context.Services.FirstOrDefaultAsync(x => x.Id == id);

                if (service == null)
                {
                    logger.LogError("(ServiceRepository.UpdateServiceAsync): id pasado inválido, service não encontrada");
                    return null;
                }

                context.Services.Remove(service);
                await context.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em ServiceRepository.DeleteServiceAsync:\n" + ex.Message);
            }
            return null;

        }
        public async Task<ServiceModel?> GetServiceByIdAsync(int id)
        {
            try
            {
                var service = await context.Services.FirstOrDefaultAsync(x => x.Id == id);

                if (service == null)
                {
                    logger.LogError("(ServiceRepository.GetServiceByIdAsync): id pasado inválido, service não encontrada");
                    return null;
                }

                return service;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em ServiceRepository.GetServiceByIdAsync:\n" + ex.Message);
            }
            return null;
        }
        public async Task<List<ServiceModel>?> GetAllServicesPaginadedAsync(int skip, int take)
        {
            try
            {
                var services = await context.Services.Skip(skip).Take(take).ToListAsync();
                return services;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em ServiceRepository.GetAllServicesPaginadedAsync:\n" + ex.Message);
            }
            return null;
        }
        public async Task<int> CountServiceAsync()
        {
            return await context.Services.CountAsync();
        }

        
    }
}
