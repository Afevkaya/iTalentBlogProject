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
        }
    }
}
