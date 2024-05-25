namespace SistOtica.Models.Sale
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Crm { get; set; }
        public SaleProtocolModel Protocol { get; set; }

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
    }
}
