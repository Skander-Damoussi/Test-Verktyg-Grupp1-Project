using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.Services
{
    public interface IAPIService
    {
        Task<int> LogInAsync(LoginModel login);
    }
}