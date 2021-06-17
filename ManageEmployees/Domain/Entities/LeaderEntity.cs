using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class LeaderEntity : EmployeeEntity
    {
        public DepartmentEntity Department { get; set; }
    }
}
