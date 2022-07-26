using AutoMapper;
using BlogAPI.Features.Author.Commands.Create;
using BlogAPI.Features.Category.Commands.Create;
using BlogAPI.Features.Post.Commands.Create;
using BlogAPI.Models;

namespace BlogAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<CreatePostCommand, Post>();
        }
    }
}
