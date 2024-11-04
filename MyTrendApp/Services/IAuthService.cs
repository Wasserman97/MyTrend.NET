
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    public interface IAuthService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
}
