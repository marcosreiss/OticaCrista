using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<PaymentModel?> CreatePaymentAsync(SaleModel sale);
        Task<PaymentModel?> UpdatePaymentAsync(int id, PaymentModel model);
        Task<PaymentModel?> DeletePaymentAsync(int id);
        Task<PaymentModel?> GetPaymentByIdAsync(int id);
        Task<List<PaymentModel>?> GetAllPaymentsPaginadedAsync(int skip, int take);
    }
}
