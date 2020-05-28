using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.Services
{
    public interface IAPIService
    {
        Task<string> LogInAsync(LoginModel login);
    }
}