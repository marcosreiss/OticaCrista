using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<List<PaymentModel>> GetAllPayments();
    }
}
