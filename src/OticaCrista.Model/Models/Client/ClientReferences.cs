namespace SistOtica.Models.Client
{
    public class ClientReferences
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; } 
    }
}
