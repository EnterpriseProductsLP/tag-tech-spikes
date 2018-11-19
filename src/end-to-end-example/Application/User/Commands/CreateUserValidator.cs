// <copyright file="CreateUserValidator.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using Application.User.Commands;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.User.Validations
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(16).WithMessage("Password must be obnoxiously long");

            RuleFor(x => x.Phone)
                .Must(HaveCountryCode)
                .When(x => x.Country == "United States")
                .WithMessage("US Users must have a country code prefix in their phone number for no apparent reason.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.");
        }

        private static bool HaveCountryCode(CreateUser model, string phoneValue, PropertyValidatorContext ctx)
        {
            return model.Phone.StartsWith("+1");
        }
    }
}
