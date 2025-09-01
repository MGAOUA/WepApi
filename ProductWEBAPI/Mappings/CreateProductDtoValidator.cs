using FluentValidation;
using ProductWEBAPI.Models;

namespace ProductWEBAPI.Mappings
{

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0); // 4 integer digits, 2 decimal places (e.g., 9999.99)

            // Complex rule example
            RuleFor(x => x.Name).Must(name => !name.Contains("bad word"))
                                .WithMessage("Product name contains a prohibited term.");
        }
    }
}
