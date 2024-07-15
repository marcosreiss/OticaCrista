using OticaCrista.Model.Models.Sale;
using SistOtica.Models.Client;
using SistOtica.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Sale
{
    public class SaleModel
    {

        #region Sale Infos

        public int Id { get; set; }
        public DateOnly SaleDate { get; set; }

        #endregion

        #region Client

        [ForeignKey("ClientId")]
        [InverseProperty("Sales")]
        public int ClientId { get; set; }
        public ClientModel Client { get; set; } 

        #endregion

        #region Product/Service and Payment

        public List<int>? ProductItemId { get; set; }
        public List<SaleProductItem>? Products { get; set; } 

        public List<int>? ServiceItemId { get; set; }
        public List<SaleServiceItem>? Services { get; set; }

        public PaymentModel Payment { get; set; } = new();

        #endregion

        #region Sale Protocol

        public string Book { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public int ServiceOrder { get; set; }

        #endregion

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
