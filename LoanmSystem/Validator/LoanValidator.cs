using FluentValidation;
using LoanmSystem.DTO;

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
            RuleFor(loan => loan.ltype).NotNull().NotEmpty()
                .Must(ltype => (ltype == "Home") || (ltype == "Study") || (ltype == "Personal"))
                .WithMessage("Applied Loan must be Home, Study or Personal");
            RuleFor(loan => loan.lterm).NotNull().NotEmpty()
                .GreaterThanOrEqualTo(1).LessThanOrEqualTo(5)
                .WithMessage("Time Period of Loan must be between 1 and 5");
        }

    }
}
