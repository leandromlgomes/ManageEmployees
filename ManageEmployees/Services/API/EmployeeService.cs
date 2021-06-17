using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.Employee;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Domain.Dtos.Employee;
using Domain.Interfaces;

namespace Services.API
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<EmployeeEntity> _repository;
        private IUtilitiesService _utilities;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<EmployeeEntity> repository
                           , IMapper mapper, IUtilitiesService utilities)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = utilities;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EmployeeResponseDomainModel> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<EmployeeResponseDomainModel>(entity) ?? new EmployeeResponseDomainModel();
        }

        public async Task<IEnumerable<EmployeeResponseDomainModel>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<EmployeeResponseDomainModel>>(listEntity);
        }

        public async Task<EmployeeResponseDomainModel> Post(EmployeeCreateDomainModel employee)
        {
            if (_utilities.ValidateEmail(employee.Email))
            {
                employee.Password = _utilities.CreateMD5Hash(employee.Password);
                var entity = _mapper.Map<EmployeeEntity>(employee);
                var result = await _repository.InsertAsync(entity);

                return _mapper.Map<EmployeeResponseDomainModel>(result);
            }
            else
            {
                return null;
            }

        }

        public async Task<EmployeeResponseDomainModel> Put(EmployeeUpdateDomainModel employee)
        {
            if (_utilities.ValidateEmail(employee.Email))
            {
                employee.Password = _utilities.CreateMD5Hash(employee.Password);
                var entity = _mapper.Map<EmployeeEntity>(employee);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<EmployeeResponseDomainModel>(result);
            }
            else
            {
                return null;
            }

        }
    }
}
