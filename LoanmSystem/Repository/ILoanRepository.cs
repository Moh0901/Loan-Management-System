using LoanmSystem.DTO;
using LoanmSystem.Model;

namespace LoanmSystem.Repository
{
    public interface ILoanRepository
    {
        List<Loan> GetAllLoans();

        Loan GetLoanById(int id);

        Loan AddLoan(LoanDTO loan);

        Loan UpdateLoanInfo(int id, LoanDTO loan);

        Loan DeleteLoan(int id);
    }
}
