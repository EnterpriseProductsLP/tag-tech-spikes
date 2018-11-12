using FluentValidation;
using FluentValidation.Validators;

namespace Application.User.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
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
        
        private static bool HaveCountryCode(CreateUserCommand model, string phoneValue, PropertyValidatorContext ctx)
        {
            return model.Phone.StartsWith("+1");
        }

    }
}
