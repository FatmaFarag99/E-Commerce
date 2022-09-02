namespace Customers.Validators
{
    using Customers.Entities;
    using Customers.ViewModels;
    using FluentValidation;

    public class CustomerValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
