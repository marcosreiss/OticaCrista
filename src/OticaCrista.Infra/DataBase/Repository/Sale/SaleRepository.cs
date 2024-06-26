using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Sale
{
    public class SaleRepository(
        IDbContextFactory<OticaCristaContext> contextFactory,
        ILogger<SaleRepository> logger) 
        : ISaleRepository
    {
        private readonly OticaCristaContext context = contextFactory.CreateDbContext();

        public async Task<SaleModel?> CreateSaleAsync(SaleModel model)
        {
            try
            {
                await context.AddAsync(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em SaleRepository.CreateSaleAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<SaleModel?> UpdateSaleAsync(int id, SaleModel model)
        {
            try
            {
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == id);
                if (sale == null)
                {
                    logger.LogError("(SaleRepository.UpdateSaleAsync): id pasado inválido, sale não encontrada");
                    return null;
                }

                #region Mapping Data
                sale.SaleDate = model.SaleDate;
                sale.ItemQt = model.ItemQt;
                sale.Discount = model.Discount;
                sale.FinalPrice = model.FinalPrice;
                sale.Observation = model.Observation;
                sale.ClientId = model.ClientId;
                sale.Products = model.Products;
                sale.Services = model.Services;
                sale.Book = model.Book;
                sale.Page = model.Page;
                sale.ServiceOrder = model.ServiceOrder;
                sale.DoctorName = model.DoctorName;
                sale.Crm = model.Crm;
                sale.OdEsferico = model.OdEsferico;
                sale.OdCilindrico = model.OdCilindrico;
                sale.OdEixo = model.OdEixo;
                sale.OdDnp = model.OdDnp;
                sale.OeEsferico = model.OeEsferico;
                sale.OeCilindrico = model.OeCilindrico;
                sale.OeEixo = model.OeEixo;
                sale.OeDnp = model.OeDnp;
                sale.Adicao = model.Adicao;
                sale.CentroOtico = model.CentroOtico;
                sale.Type = model.Type;
                sale.Ref = model.Ref;
                #endregion

                context.Sales.Update(sale);
                await context.SaveChangesAsync();

                return sale;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em SaleRepository.UpdateSaleAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<SaleModel?> DeleteSaleAsync(int id)
        {
            try
            {
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == id);
                if (sale == null)
                {
                    logger.LogError("(SaleRepository.DeleteSaleAsync): id pasado inválido, sale não encontrada");
                    return null;
                }

                context.Sales.Remove(sale);
                await context.SaveChangesAsync();

                return sale;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em SaleRepository.DeleteSaleAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<SaleModel?> GetSaleByIdAsync(int id)
        {
            try
            {
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == id);
                if (sale == null)
                {
                    logger.LogError("(SaleRepository.GetSaleByIdAsync): id pasado inválido, sale não encontrada");
                    return null;
                }

                return sale;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em SaleRepository.GetSaleByIdAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<List<SaleModel>?> GetAllSalesPagedAsync(int skip, int take)
        {
            try
            {
                var sales = await context.Sales.Skip(skip).Take(take).ToListAsync();
                return sales;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro em SaleRepository.GetAllSalesPagedAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<int> GetSaleCountAsync()
        {
            return await context.Sales.CountAsync();
        }
    }
}
