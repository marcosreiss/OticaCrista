﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OticaCrista.communication.Requests.Sale;
using OticaCrista.Model.Models.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Sale
{
    public class SaleRepository(
        IDbContextFactory<OticaCristaContext> contextFactory,
        ILogger<SaleRepository> logger) 
        : ISaleRepository
    {
        private readonly OticaCristaContext context = contextFactory.CreateDbContext();

        private SaleModel SaleMap(SaleRequest request)
        {
            var sale = new SaleModel
            {
                SaleDate = request.SaleDate,
                ClientId = request.ClientId,
                
                Book = request.Book ?? string.Empty,
                Page = request.Page ?? string.Empty,
                ServiceOrder = request.ServiceOrder,
                DoctorName = request.DoctorName,
                Crm = request.Crm,

                OdEsferico = request.OdEsferico,
                OdCilindrico = request.OdCilindrico,
                OdEixo = request.OdEixo,
                OdDnp = request.OdDnp,

                OeEsferico = request.OeEsferico,
                OeCilindrico = request.OeCilindrico,
                OeEixo = request.OeEixo,
                OeDnp = request.OeDnp,

                Adicao = request.Adicao,
                CentroOtico = request.CentroOtico,

                Type = request.Type,
                Ref = request.Ref
            };

            if (request.ProductItems?.Count > 0)
            {
                sale.Products = new List<SaleProductItem>();
                foreach (var productRequest in request.ProductItems)
                {
                    var product = ProductMap(productRequest);
                    sale.Products.Add(product);
                }
            }
            if (request.ServiceItems?.Count > 0)
            {
                sale.Services = new List<SaleServiceItem>();
                foreach (var serviceRequest in request.ServiceItems)
                {
                    var service = ServiceMap(serviceRequest);
                    sale.Services.Add(service);
                }
            }

            return sale;
        }
        private SaleProductItem ProductMap(SaleProductRequest request)
        {
            var product = new SaleProductItem
            {
                ProductId = request.ProductId,
                Amount = request.Amount,
                Discount = request.Discount,
                FinalPrice = request.FinalPrice,
                Observation = request.Observation,
            };
            var stock =  context.Products.FirstOrDefault( x => x.Id == request.ProductId );
            stock.Quantity -= product.Amount;
            context.Products.Update(stock);
            return product;
        }
        private static SaleServiceItem ServiceMap(SaleServiceRequest request)
        {
            var service = new SaleServiceItem
            {
                ServiceId = request.ServiceId,
                Discount = request.Discount,
                Amount = request.Amount,
                FinalPrice = request.FinalPrice,
                Observation = request?.Observation,
            };
            return service;
        }


        public async Task<SaleModel?> CreateSaleAsync(SaleRequest request)
        {
            try
            {
                var sale = SaleMap(request);
                

                await context.Sales.AddAsync(sale);
                await context.SaveChangesAsync();
                return sale;
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
                //sale.ItemQt = request.ItemQt;
                //sale.Discount = request.Discount;
                //sale.FinalPrice = request.FinalPrice;
                //sale.Observation = request.Observation;
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
                var sale = await context.Sales
                    .Include(x => x.Products)
                    .Include(x => x.Services)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
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
