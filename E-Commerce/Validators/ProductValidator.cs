﻿namespace ECommerce
{
    using FluentValidation;

    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.NameSecondLanguage).NotEmpty().WithMessage("NameSecondLanguage cannot be empty");
        }
    }
}