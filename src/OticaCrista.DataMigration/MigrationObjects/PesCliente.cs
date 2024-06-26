namespace OticaCrista.DataMigration.MigrationObjects
{
    public class PesCliente
    {
        public int ClientId { get; set; }
        public string Spouse { get; set; } = string.Empty;
        public string Parents {  get; set; } = string.Empty;
        public string RefName1 { get; set; } = string.Empty;
        public string RefPhoneNumber1 {  get; set; } = string.Empty;
        public string RefName2 { get; set;} = string.Empty;
        public string RefPhoneNumber2 { get; set; } = string.Empty;
        public string RefName3 { get; set; } = string.Empty;
        public string RefPhoneNumber3 { get; set; } = string.Empty;
        public bool Spc {  get; set; }
        public string Rg { get; set; } = string.Empty;
        public string Ocupation { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string PreciusSales { get; set; } = string.Empty;
    }
}
