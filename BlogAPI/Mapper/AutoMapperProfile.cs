using AutoMapper;
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
            CreateMap<CreateAuthorDTO, Author>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CreatePostDTO, Post>();
        }
    }
}
