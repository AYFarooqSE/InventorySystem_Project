using AutoMapper;
using InventorySystem_API.DTOs;
using InventorySystem_Domain.Models;

namespace InventorySystem_API.Mappers
{
    public class MappersProfile:Profile
    {
        public MappersProfile()
        {
            CreateMap<CustomersModel, CustomerDto>();
            CreateMap<CustomerDto, CustomersModel >();
        }
    }
}
