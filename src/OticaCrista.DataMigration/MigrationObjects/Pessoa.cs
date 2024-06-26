using OticaCrista.Model.Models.Enums;

namespace OticaCrista.DataMigration.MigrationObjects
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhoneNumber2 { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string AddressComplement { get; set; } = string.Empty;
        public string Email { get;set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public DateTime BornDate {  get; set; } 
        public Gender Gender { get; set; }

    }
}
