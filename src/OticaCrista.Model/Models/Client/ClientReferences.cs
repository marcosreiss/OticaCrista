using System.Text.Json.Serialization;

namespace SistOtica.Models.Client
{
    public class ClientReferences
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        [JsonIgnore]
        public ClientModel Client { get; set; } 
    }
}
