using Domain.Dtos.Login;
using System.Threading.Tasks;

namespace Domain.Interfaces.API.Services.Login
{
    public interface ILoginService
    {
        Task<bool> Login(LoginDomainModel login);
    }
}
