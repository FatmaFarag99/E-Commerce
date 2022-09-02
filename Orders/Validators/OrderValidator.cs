namespace Orders.Validators
{
    using FluentValidation;
    using Orders.ViewModels;

    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.ShippingAddress).NotEmpty().WithMessage("Shipping Address cannot be empty");
            RuleFor(p => p.TotalPrice).NotEmpty().WithMessage("Total Price  cannot be empty");
            RuleFor(p => p.ShippedDate).NotEmpty().WithMessage("Total Price  cannot be empty");
          
            //ToDo: NotNull ? NotEmpty
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("Total Price  cannot be empty");
        }
    }
}
