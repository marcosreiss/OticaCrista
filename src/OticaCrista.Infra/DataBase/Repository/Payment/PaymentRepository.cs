using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Payment
{
    public class PaymentRepository(
        IDbContextFactory<OticaCristaContext> _factory,
        ILogger<PaymentRepository> _logger) 
        : IPaymentRepository
    {
        private OticaCristaContext context = _factory.CreateDbContext();



        public async Task<PaymentModel?> CreatePayment(SaleModel sale)
        {
            var payment = new PaymentModel
            {
                SaleId = sale.Id,
                DueDate = DateOnly.FromDateTime(DateTime.Now),
            };

            try
            {
                await context.Payments.AddAsync(payment);
                await context.SaveChangesAsync();
                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.CreatePayment:\n" + ex.Message);
            }
            return null;

        }

        public async Task<PaymentModel?> UpdatePayment(int id, PaymentModel model)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.UpdatePayment (Invalid Id)");
                    return null;
                }

                payment.Discount = model.Discount;
                payment.Method = model.Method;
                payment.DownPayment = model.DownPayment;
                payment.Installments = model.Installments;

                context.Payments.Update(payment);
                await context.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.UpdatePayment:\n" + ex.Message);
            }
            return null;
        }

        public async Task<PaymentModel?> DeletePayment(int id)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.DeletePayment (Invalid Id)");
                    return null;
                }

                context.Payments.Remove(payment);
                await context.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.DeletePayment:\n" + ex.Message);
            }
            return null;
        }

        public async Task<List<PaymentModel>?> GetAllPaymentsPaginaded(int skip, int take)
        {
            try
            {
                var payments = await context.Payments
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                return payments;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.GetAllPaymentsPaginaded:\n" + ex.Message);
            }
            return null;
        }

        public async Task<PaymentModel?> GetPaymentById(int id)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.GetPaymentById (Invalid Id)");
                    return null;
                }

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.GetPaymentById:\n" + ex.Message);
            }
            return null;
        }

        
    }
}
