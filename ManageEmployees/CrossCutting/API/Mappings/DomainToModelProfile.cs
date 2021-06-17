using AutoMapper;
using Domain.Dtos.Employee;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {

            CreateMap<EmployeeEntity, EmployeeCreateDomainModel>()
               .ReverseMap();
            CreateMap<EmployeeEntity, EmployeeUpdateDomainModel>()
                .ReverseMap();
        }
    }
}
