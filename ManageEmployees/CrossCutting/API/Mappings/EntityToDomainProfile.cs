using AutoMapper;
using Domain.Dtos.Employee;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDomainProfile : Profile
    {
        public EntityToDomainProfile()
        {

            CreateMap<EmployeeResponseDomainModel, EmployeeEntity>()
            .ReverseMap();

        }
    }
}
