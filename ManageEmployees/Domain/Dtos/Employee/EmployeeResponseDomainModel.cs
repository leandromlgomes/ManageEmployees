using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Employee
{
    public class EmployeeResponseDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string EmployeeNumber { get; set; }
        public string LeaderName { get; set; }
    }
}
