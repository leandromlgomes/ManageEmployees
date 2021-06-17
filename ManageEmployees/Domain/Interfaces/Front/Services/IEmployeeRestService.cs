using Domain.Dtos.Employee;
using Domain.Helpers;
using Domain.ViewModels.Employee;
using System.Threading.Tasks;

namespace Domain.Interfaces.Front.Services
{
    public interface IEmployeeRestService
    {
        Task<EmployeeEditViewModel> Get(string token, int id);
        Task<EmployeeViewModel> GetAll(string token);
        Task<QueryResult<EmployeeResponseDomainModel>> Post(string token, EmployeeCreateViewModel employee);
        Task<QueryResult<EmployeeResponseDomainModel>> Put(string token, EmployeeEditViewModel employee);
        Task<QueryResult<bool>> Delete(string token, int id);
    }
}
