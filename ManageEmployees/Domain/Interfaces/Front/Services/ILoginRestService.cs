using Domain.Dtos.Employee;
using Domain.Helpers;
using Domain.ViewModels.Employee;
using Domain.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Front.Services
{
    public interface ILoginRestService
    {
        Task<QueryResult<string>> Login(LoginViewModel login);
    }
}
