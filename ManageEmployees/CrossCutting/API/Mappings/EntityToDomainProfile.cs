using AutoMapper;
using Domain.Dtos.Employee;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
