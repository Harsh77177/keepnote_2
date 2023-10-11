using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public interface IUserRepo
    {
        bool RegisterUser(User user);
        bool UpdateUser(int id, User user);
        User GetUserById(int userId);
        bool ValidateUser(int userId, string password);
        bool DeleteUser(int userId);

    }
}
