using UserAuthenticationSystem.model;

namespace UserAuthenticationSystem.services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<User> Login(string email, string password);
    }
}
