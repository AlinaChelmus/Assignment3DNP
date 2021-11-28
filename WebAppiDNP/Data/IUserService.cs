using WebAppiDNP.Models;

namespace WebAppiDNP.Data
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        void RegisterUser(User user);
    }
}