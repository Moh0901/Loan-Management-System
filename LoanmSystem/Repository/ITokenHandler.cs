using LoanmSystem.Model;

namespace LoanmSystem.Repository
{
    public interface ITokenHandler
    {
        String CreateToken(User user);
    }
}
