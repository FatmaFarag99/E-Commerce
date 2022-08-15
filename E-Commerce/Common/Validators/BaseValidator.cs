namespace ECommerce.Common.Validators
{
    using ECommerce.Common.ViewModels;
    using FluentValidation;

    public class BaseValidator<TViewModel> : AbstractValidator<TViewModel> 
        where TViewModel : BaseViewModel
    {
        public BaseValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.NameSecondLanguage).NotEmpty();
        }
    }
}
