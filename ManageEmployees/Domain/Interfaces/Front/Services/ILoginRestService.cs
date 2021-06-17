using Domain.Helpers;
using Domain.ViewModels.Login;
using System.Threading.Tasks;

namespace Domain.Interfaces.Front.Services
{
    public interface ILoginRestService
    {
        Task<QueryResult<string>> Login(LoginViewModel login);
    }
}
