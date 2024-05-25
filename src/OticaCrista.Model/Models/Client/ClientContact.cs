using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Client
{
    public class ClientContact
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("PhoneNumbers")]
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

    }
}
