﻿namespace ECommerce
{
    using FluentValidation;

    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.NameSecondLanguage).NotEmpty().WithMessage("NameSecondLanguage cannot be empty");
        }
    }
}