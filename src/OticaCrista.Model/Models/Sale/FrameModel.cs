using SistOtica.Models.Enums;

namespace SistOtica.Models.Sale
{
    public class FrameModel
    {
        public int Id { get; set; }
        public FrameType Type { get; set; }
        public string Ref { get; set; }

        public SaleModel Sale { get; set; }
    }
}
