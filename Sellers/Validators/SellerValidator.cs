namespace Sellers.Validators
{
    using FluentValidation;
    using Sellers.ViewModels;

    public class SellerValidator : AbstractValidator<SellerViewModel>
    {
        public SellerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
