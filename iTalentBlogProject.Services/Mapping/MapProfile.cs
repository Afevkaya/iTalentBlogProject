using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;

namespace iTalentBlogProject.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<UpdatePostDto, Post>().ReverseMap();
            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<CommentDto, Comment>();
            CreateMap<(List<Post>, int), GetPostWithPagedDto>()
                .ForMember(p => p.Post, t => t.MapFrom(s => s.Item1))
                .ForMember(p => p.totalCount, t => t.MapFrom(s => s.Item2));
            CreateMap<PostWithCommentsDto, Post>().ReverseMap();
        }
    }
}
