using Domain.Dtos.Employee;
using System.Collections.Generic;

namespace Domain.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public IList<EmployeeResponseDomainModel> Employees { get; set; }
    }
}
