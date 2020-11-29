using AutoMapper;
using Categories.Data;
using Categories.Dtos;
using Categories.Models;

namespace Categories.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            // Source -> Target
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}