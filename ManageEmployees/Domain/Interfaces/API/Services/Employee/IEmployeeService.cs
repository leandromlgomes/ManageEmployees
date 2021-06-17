using Domain.Dtos.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Employee
{
    public interface IEmployeeService
    {
        Task<EmployeeResponseDomainModel> Get(int id);
        Task<IEnumerable<EmployeeResponseDomainModel>> GetAll();
        Task<EmployeeResponseDomainModel> Post(EmployeeCreateDomainModel employee);
        Task<EmployeeResponseDomainModel> Put(EmployeeUpdateDomainModel employee);
        Task<bool> Delete(int id);
    }
}
