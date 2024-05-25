using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Sale
{
    public class SaleProtocolModel
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public string Page { get; set; }
        public int ServiceOrder { get; set; }

        [ForeignKey("PrescriptionId")]
        public int PrescriptionId { get; set; }
        public PrescriptionModel Prescription { get; set; }

        public SaleModel Sale { get; set; }
    }
}
