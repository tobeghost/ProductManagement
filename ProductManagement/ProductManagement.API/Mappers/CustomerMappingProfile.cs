using AutoMapper;
using PM.Domain.Customers;
using ProductManagement.API.Models.Login;

namespace ProductManagement.API.Mappers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, SignInDto>()
               .ForMember(p => p.Username, m => m.MapFrom(f => f.Username))
               .ForMember(p => p.Name, m => m.MapFrom(f => $"{f.FirstName} {f.LastName}"));
        }
    }
}
