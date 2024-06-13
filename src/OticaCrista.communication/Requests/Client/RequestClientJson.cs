namespace OticaCrista.communication.Requests.Client
{
    public class RequestClientJson
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }
        
        public DateOnly BornDate { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string SpouseName { get; set; }  

        public string EmailAddress { get; set; }

        public string Company { get; set; }

        public string Ocupation { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public string AddressComplement { get; set; }

        public bool Negativated { get; set; }

        public string Observation { get; set; }

        public List<ContactJson> Contacts { get; set; }
        public List<ReferenceJson> References { get; set; }
    }
}
