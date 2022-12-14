using LoanmSystem.DTO;
using LoanmSystem.Model;

namespace LoanmSystem.Repository
{
    public interface IUserRepository
    {
        User Authenticate(Login user);

        List<User> GetAllUsers();

        User GetUserById(int id);

        User AddUser(UserDTO user);

        User UpdateUser(int id, UserDTO user);

        User DeleteUser(int id);
    }
}
