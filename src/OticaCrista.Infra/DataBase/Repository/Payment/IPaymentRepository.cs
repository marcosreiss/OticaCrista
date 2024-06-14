using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<List<PaymentModel>> GetAllPayments();
        Task<PaymentModel> GetPaymentById(int id);
        Task<PaymentModel> CreatePayment(SaleModel sale);
        Task<PaymentModel> UpdatePayment(int id);
        Task<PaymentModel> DeletePayment(int id);
    }
}
