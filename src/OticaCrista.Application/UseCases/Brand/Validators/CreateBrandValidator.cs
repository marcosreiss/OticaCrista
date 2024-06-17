using FluentValidation;
using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository.Brand;

namespace OticaCrista.Application.UseCases.Brand.Validators
{
    public class CreateBrandValidator : AbstractValidator<BrandRequest>
    {
        public CreateBrandValidator(IBrandRepository _repository)
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Brand Name is Required")
                .MaximumLength(255).WithMessage("Name Max Length 255");
        }
    }
}
