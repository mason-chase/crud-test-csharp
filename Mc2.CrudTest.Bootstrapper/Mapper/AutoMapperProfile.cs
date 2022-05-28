using AutoMapper;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Bootstrapper.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
    }
}