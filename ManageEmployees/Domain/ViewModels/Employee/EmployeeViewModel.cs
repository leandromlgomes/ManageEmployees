using Domain.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public IList<EmployeeResponseDomainModel> Employees { get; set; }
    }
}
