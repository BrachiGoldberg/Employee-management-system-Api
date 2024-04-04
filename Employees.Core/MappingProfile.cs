using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyDetailsDto>().ReverseMap();
            CreateMap<EmployeePosition, EmployeePositionDto>().ReverseMap();
        }
    }
}
