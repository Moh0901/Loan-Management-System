using FluentValidation;
using LoanmSystem.DTO;
using LoanmSystem.Model;
using System.Data;

namespace LoanmSystem.Validator
{
    public class UserValidator: AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.name).NotNull().NotEmpty(); 
            RuleFor(user => user.username).NotNull().MaximumLength(10).WithMessage("Usernmae can't be empty");
            RuleFor(user => user.password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(4).WithMessage("Your password length must be at least 4.")
                    .MaximumLength(8).WithMessage("Your password length must not exceed 8.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
            RuleFor(user => user.role).NotNull().NotEmpty().Equal("User");
        }
    }
}
