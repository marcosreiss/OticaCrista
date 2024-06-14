using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<List<PaymentModel>?> GetAllPaymentsPaginaded(int skip, int take);
        Task<PaymentModel?> GetPaymentById(int id);
        Task<PaymentModel?> CreatePayment(SaleModel sale);
        Task<PaymentModel?> UpdatePayment(int id, PaymentModel model);
        Task<PaymentModel?> DeletePayment(int id);
    }
}
