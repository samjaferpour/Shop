using AutoMapper;
using Shop.Application.CQRS.CategoryFeatures.Commands;
using Shop.Application.CQRS.CategoryFeatures.Queries;
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
            CreateMap<IEnumerable<GetAllCategoriesQueryResponse>,IEnumerable<Category>>();
            CreateMap<Category, AddCategoryResponse>();
        }
    }
}
