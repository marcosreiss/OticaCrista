using SistOtica.Models.Enums;
using SistOtica.Models.Sale;

namespace OticaCrista.communication.Requests.Sale
{
    public class SaleRequest
    {
        #region Sale Infos

        public DateOnly SaleDate { get; set; }
        public int ItemQt { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string Observation { get; set; } = string.Empty;

        #endregion

        public int ClientId { get; set; }

        #region Product/Service and Payment

        public List<int>? ProducstId { get; set; }
        public List<int>? ServicesId { get; set; }
        public PaymentModel Payment { get; set; } = new();

        #endregion

        #region Sale Protocol

        public string Book { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public int ServiceOrder { get; set; }

        #endregion

        #region Prescription

        public string DoctorName { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;

        public double OdEsferico { get; set; }
        public double OdCilindrico { get; set; }
        public double OdEixo { get; set; }
        public double OdDnp { get; set; }

        public double OeEsferico { get; set; }
        public double OeCilindrico { get; set; }
        public double OeEixo { get; set; }
        public double OeDnp { get; set; }

        public double Adicao { get; set; }
        public double CentroOtico { get; set; }

        #endregion

        #region Frame

        public FrameType? Type { get; set; }
        public string? Ref { get; set; }

        #endregion
    }
}
