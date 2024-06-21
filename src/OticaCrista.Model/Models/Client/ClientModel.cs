using SistOtica.Models.Sale;
using System.ComponentModel.DataAnnotations;

namespace SistOtica.Models.Client
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Cpf {  get; set; } = string.Empty;

        public string Rg { get; set; } = string.Empty;

        public ICollection<ClientContact> Contacts { get; set; } = new List<ClientContact>();
        public ICollection<ClientReferences> References { get; set; } = new List<ClientReferences>();

        public DateOnly BornDate {  get; set; }

        public string FatherName { get; set; } = string.Empty;

        public string MotherName { get; set; } = string.Empty;

        public string SpouseName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty; 

        public string Ocupation { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string Neighborhood { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        public string AddressComplement { get; set; } = string.Empty;

        public bool Negativated { get; set; }

        public string Observation { get; set; } = string.Empty;

        public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    }
}
