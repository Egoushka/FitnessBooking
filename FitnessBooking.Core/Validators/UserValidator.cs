using FitnessBooking.Core.Models.Dto.User;
using FluentValidation;

namespace FitnessBooking.Core.Validators
{
    public class UserValidator : AbstractValidator<RegisterUserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .Equal(user => user.RepeatPassword);

            RuleFor(user => user.Email)
                .EmailAddress();
        }
    }
}