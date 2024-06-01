using SistOtica.Models.Sale;
using System.ComponentModel.DataAnnotations;

namespace SistOtica.Models.Client
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf {  get; set; }

        public string Rg { get; set; }

        public ICollection<ClientContact> PhoneNumber { get; set; } = new List<ClientContact>();
        public ICollection<ClientReferences> References { get; set; } = new List<ClientReferences>();

        public DateOnly BornDate {  get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string SpouseName {  get; set; }

        public string EmailAddress { get; set; }

        public string Company {  get; set; }

        public string Ocupation { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public string AddressComplement { get; set; }

        public bool Negativated { get; set; }

        public string Observation { get; set; }

        public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    }
}
