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
        private readonly OticaCristaContext context = _factory.CreateDbContext();


        public async Task<PaymentModel?> CreatePaymentAsync(SaleModel sale)
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
                _logger.LogError(ex, "Erro em PaymentRepository.CreatePaymentAsync:\n" + ex.Message);
            }
            return null;

        }

        public async Task<PaymentModel?> UpdatePaymentAsync(int id, PaymentModel model)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.UpdatePaymentAsync (Invalid Id)");
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
                _logger.LogError(ex, "Erro em PaymentRepository.UpdatePaymentAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<PaymentModel?> DeletePaymentAsync(int id)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.DeletePaymentAsync (Invalid Id)");
                    return null;
                }

                context.Payments.Remove(payment);
                await context.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.DeletePaymentAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<PaymentModel?> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (payment == null)
                {
                    _logger
                        .LogInformation
                        ("payment null in PaymentRepository.GetPaymentByIdAsync (Invalid Id)");
                    return null;
                }

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em PaymentRepository.GetPaymentByIdAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<List<PaymentModel>?> GetAllPaymentsPagedAsync(int skip, int take)
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
                _logger.LogError(ex, "Erro em PaymentRepository.GetAllPaymentsPagedAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<int> GetPaymentCountAsync()
        {
            return await context.Payments.CountAsync();
        }
    }
}
