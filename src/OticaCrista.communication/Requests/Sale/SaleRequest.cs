using OticaCrista.Model.Models.Sale;
using SistOtica.Models.Enums;
using SistOtica.Models.Sale;

namespace OticaCrista.communication.Requests.Sale
{
    public class SaleRequest
    {

        public DateOnly SaleDate { get; set; }

        public int ClientId { get; set; }

        public List<SaleProductRequest>? ProductItems { get; set; }
        public List<SaleServiceRequest>? ServiceItems { get; set; }

        public string? Book { get; set; } 
        public string? Page { get; set; } 
        public int ServiceOrder { get; set; }

        #region Prescription

        public string? DoctorName { get; set; }
        public string? Crm { get; set; } 

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
