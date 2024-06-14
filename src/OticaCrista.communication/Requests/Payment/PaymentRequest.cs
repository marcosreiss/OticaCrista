using SistOtica.Models.Enums;

namespace OticaCrista.communication.Requests.Payment
{
    public class PaymentRequest
    {
        public double Discount { get; set; }

        public PaymentMethod Method { get; set; }

        public double DownPayment { get; set; } 

        public int Installments { get; set; }
    }
}
