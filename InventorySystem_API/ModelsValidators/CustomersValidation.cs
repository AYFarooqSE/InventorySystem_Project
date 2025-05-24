using FluentValidation;
using FluentValidation.Validators;
using InventorySystem_API.DTOs;

namespace InventorySystem_API.ModelsValidators
{
    public class CustomersValidation:AbstractValidator<CustomerDto>
    {
        public CustomersValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name Cannot be Empty");
            RuleFor(x => x.FirstName).MaximumLength(20).WithMessage("First Name Character must be below 20");


            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name Cannot be Empty");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Last Name Character must be below 20");


        }
    }
}
