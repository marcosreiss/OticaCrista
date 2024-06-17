using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistOtica.Models.Client
{
    public class ClientContact
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        [ForeignKey("ClientId")]
        [InverseProperty("PhoneNumbers")]
        public int ClientId { get; set; }
        [JsonIgnore]
        public ClientModel Client { get; set; }
    }
}
