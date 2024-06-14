namespace SistOtica.Models.Client
{
    public class ClientReferences
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; } 
    }
}
