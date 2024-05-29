using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OticaCrista.communication.Requests.Client;
using OticaCrista.Infra.DataBase;

namespace OticaCrista.Application.UseCases.Client.Validators
{
    public class CreateClientValidator : AbstractValidator<RequestClientJson>
    {
        
        public CreateClientValidator()
        {

            RuleFor(client => client.Name).NotEmpty().WithMessage("Name is required")
                .Length(4, 255).WithMessage("Name lenth must be between 4 and 255 caracters")
                .MustAsync(BeUnique).WithMessage("This client name already exists");

            RuleFor(client => client.Cpf).Length(11)
                .WithMessage("Cpf must have 11 caracters");

            RuleFor(client => client.Rg).Length(7, 9)
                .WithMessage("Rg lenth must be between 7 and 9 caracters");

            RuleFor(client => client.BornDate).Must(date => date < new DateOnly(2023, 12, 31))
                .WithMessage("Invalid BornDate");

            RuleFor(client => client.FatherName).Length(4, 255)
                .WithMessage("FatherName lenth must be between 4 and 255 caracters");

            RuleFor(client => client.MotherName).Length(4, 255)
                .WithMessage("MotherName lenth must be between 4 and 255 caracters");

            RuleFor(client => client.SpouseName).Length(4, 255)
                .WithMessage("SpouseName lenth must be between 4 and 255 caracters");

            RuleFor(c => c.EmailAddress).EmailAddress()
                .WithMessage("Invalid Email Address");

            RuleFor(client => client.Company).Length(4, 155)
                .WithMessage("Company lenth must be between 4 and 155 caracters");

            RuleFor(client => client.Ocupation).Length(4, 155)
                .WithMessage("Ocupation lenth must be between 4 and 155 caracters");

            RuleFor(client => client.Street).Length(4, 255)
                .WithMessage("Street lenth must be between 4 and 255 caracters");

            RuleFor(client => client.Neighborhood).Length(4, 155)
                .WithMessage("Neighborhood lenth must be between 4 and 155 caracters");

            RuleFor(client => client.City).Length(4, 155)
                .WithMessage("City lenth must be between 4 and 155 caracters");

            RuleFor(client => client.Uf).Length(4, 100)
                .WithMessage("Uf lenth must be between 4 and 100 caracters");

            RuleFor(client => client.Cep).Length(8)
                .WithMessage("Cep lenth must be 8 caracters");

            RuleFor(client => client.AddressComplement).Length(4, 255)
                .WithMessage("AddressComplement lenth must be between 4 and 255 caracters");

            RuleFor(client=> client.Negativated).Must(n=> n.GetType() == typeof(bool))
                .WithMessage("Negativated must be a boolean");

            RuleFor(client => client.Observation).Length(4, 255)
                .WithMessage("Observation lenth must be between 4 and 255 caracters");
        }

        private async Task<bool> BeUnique(String name, CancellationToken cancellationToken)
        {
            //var factory = new OticaCristaContextFactory();
            //var context = factory.CreateDbContext();
            

            return await context.Clients.AllAsync(c=> c.Name != name, cancellationToken);
             
        }
    }
}
