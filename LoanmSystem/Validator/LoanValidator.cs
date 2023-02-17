using FluentValidation;
using LoanmSystem.DTO;
using LoanmSystem.Model;

namespace LoanmSystem.Validator
{
    public class LoanValidator : AbstractValidator<LoanDTO>
    {
        public LoanValidator()
        {
            RuleFor(loan => loan.fname).NotNull().NotEmpty();
            RuleFor(loan => loan.lname).NotNull().NotEmpty();
            RuleFor(loan => loan.paddress).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(loan => loan.lnum).NotNull().NotEmpty();
            RuleFor(loan => loan.lamount).NotNull().NotEmpty().GreaterThanOrEqualTo(200000);
            RuleFor(loan => loan.ltype).NotNull().NotEmpty();
            RuleFor(loan => loan.lterm).NotNull().NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);
        }

    }
}
