using Domain.Entities;
using Domain.Interfaces.Repository;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Domain.Dtos.Employee;
using Domain.Interfaces;
using System.Linq;
using Domain.Dtos.Login;
using Domain.Interfaces.API.Services.Login;

namespace Services.API
{
    public class LoginService : ILoginService
    {
        private IRepository<EmployeeEntity> _repository;
        private IUtilitiesService _utilities;
        private readonly IMapper _mapper;

        public LoginService(IRepository<EmployeeEntity> repository
                           , IMapper mapper, IUtilitiesService utilities)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = utilities;
        }                

        public async Task<bool> Login(LoginDomainModel login)
        {
            var loginValidation = false;

            var listEntity = await _repository.SelectAsync();
            var listEmployees = _mapper.Map<IEnumerable<EmployeeResponseDomainModel>>(listEntity).ToList();

            if (listEmployees.Count == 0)
            {
                return loginValidation;
            }

            var employee = listEmployees.Where(x => x.Email == login.UserName && x.Password == _utilities.CreateMD5Hash(login.Password)).FirstOrDefault();
            loginValidation = (employee != null) ? true : false;

            return loginValidation;
        }
                
    }
}
