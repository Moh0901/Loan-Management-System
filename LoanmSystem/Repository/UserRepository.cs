using LoanmSystem.DTO;
using LoanmSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanmSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _db;

        public UserRepository(DBContext db)
        {
            _db = db;
        }

        public User Authenticate(Login user)
        {
            var loggedUser = _db.user.
                FirstOrDefault(x => x.username.ToLower() == user.username.ToLower() && x.password == user.password);
            //.Find(x => x.username.Equals(username, StringComparison.InvariantCultureIgnoreCase)&& x.password==user.password);
            /*.Find(x => x.username.ToLower() == user.username.ToLower() && x.password == user.password);*/

            if (loggedUser == null)
            {
                return null;
            }
            // loggedUser.password = "*************";
            return loggedUser;
        }

        public List<User> GetAllUsers()
        {
            var users = _db.user.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            var user = _db.user.Find(id);
            return user;
        }


        public User AddUser(UserDTO user)
        {
            var newUser = new Model.User()
            {
                name = user.name,
                username = user.username,
                password = user.password,
                role = user.role,
            };
            _db.user.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public User DeleteUser(int id)
        {
            var user = _db.user.Find(id);
            if (user == null)
            {
                return null;
            }
            _db.user.Remove(user);
            _db.SaveChanges();
            return user;
        }

        public User UpdateUser(int id, UserDTO user)
        {
            var updateUser = new Model.User()
            {
                id = id,
                name = user.name,
                username = user.username,
                password = user.password,
                role = user.role
            };

            _db.Entry(updateUser).State = EntityState.Modified;

            _db.SaveChanges();
            return _db.user.Find(id);
        }
    }
}
