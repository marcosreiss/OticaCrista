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



        public async Task<PaymentModel> CreatePayment(SaleModel sale)
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
                
            }
        }

        public async Task<PaymentModel> UpdatePayment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentModel> DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PaymentModel>> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentModel> GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
