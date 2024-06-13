using SistOtica.Models.Client;
using SistOtica.Models.Enums;
using SistOtica.Models.Product;
using SistOtica.Models.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Sale
{
    public class SaleModel
    {

        #region Sale Infos

        public int Id { get; set; }
        public DateOnly SaleDate { get; set; }
        public int ItemQt { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string Observation { get; set; } = string.Empty;

        #endregion

        #region Client

        [ForeignKey("ClientId")]
        [InverseProperty("Sales")]
        public int ClientId { get; set; }
        public ClientModel Client { get; set; } 

        #endregion

        #region Product/Service and Payment

        public ICollection<ProductModel>? Products { get; set; } 

        public ICollection<ServiceModel>? Services { get; set; }

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

        public FrameType Type { get; set; }
        public string Ref { get; set; } = string.Empty;

        #endregion

    }
}
