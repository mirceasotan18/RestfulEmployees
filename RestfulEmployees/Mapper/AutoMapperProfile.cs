using AutoMapper;
using RestfulEmployees.Dtos;
using RestfulEmployees.Models;

namespace RestfulEmployees.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDto, EmployeeModel>();
        }
    }
}
