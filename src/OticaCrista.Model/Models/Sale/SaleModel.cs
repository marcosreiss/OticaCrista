using SistOtica.Models.Client;
using SistOtica.Models.Product;
using SistOtica.Models.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Sale
{
    public class SaleModel
    {
        public int Id { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("Sales")]
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

        public DateOnly SaleDate { get; set; }
        public int ItemQt { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string Observation { get; set; }

        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();

        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();

        public PaymentModel Payment { get; set; }

        [ForeignKey("ProtocolId")]    
        public int ProtocolId { get; set; }
        public SaleProtocolModel Protocol { get; set; }

        [ForeignKey("FrameId")]
        public int FrameId { get; set; }
        public FrameModel Frame { get; set; }


    }
}
