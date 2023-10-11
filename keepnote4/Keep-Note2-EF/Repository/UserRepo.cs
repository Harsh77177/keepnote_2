using Keep_Note4.Context;
using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public class UserRepo : IUserRepo
    {
        KeepDbContext _context;
        public UserRepo(KeepDbContext context)
        {
            _context = context;
        }

        public bool DeleteUser(int userId)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == userId);
            if (obj != null)
            {
                _context.users.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserById(int userId)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == userId);
            if (obj != null)
                return obj;
            return null;
        }

        public bool RegisterUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(int id, User user)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == id);
            if (obj != null)
            {
                obj.UserName = user.UserName;
                obj.CreatedAt = user.CreatedAt;
                obj.Contact = user.Contact;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ValidateUser(int userId, string password)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == userId && x.Password == password);
            if (obj == null)
                return false;
            return true;
        }
    }
}
