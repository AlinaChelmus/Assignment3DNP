using System.Threading.Tasks;
using BlazorAppDNP.Models;

namespace BlazorAppDNP.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
        Task RegisterUser(User user);
    }
}