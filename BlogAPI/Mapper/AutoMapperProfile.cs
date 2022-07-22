using AutoMapper;
using BlogAPI.Features.Category.Commands.Create;
using BlogAPI.Models;
using BlogAPI.Models.ModelsDTO.AuthorDTO;
using BlogAPI.Models.ModelsDTO.Category;
using BlogAPI.Models.ModelsDTO.PostDTO;

namespace BlogAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateCategoryCommand, Author>();
        }
    }
}
