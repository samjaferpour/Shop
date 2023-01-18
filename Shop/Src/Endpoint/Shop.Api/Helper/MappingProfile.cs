using AutoMapper;
using Shop.Contract.Dtos;
using Shop.Domain.Entities;

namespace Shop.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CategoryRequest>().ReverseMap();
        }
    }
}
