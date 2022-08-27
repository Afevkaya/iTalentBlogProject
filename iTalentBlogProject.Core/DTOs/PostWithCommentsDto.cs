using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class PostWithCommentsDto
    {
        public PostDto PostDto { get; set; }
        public List<CommentDto> CommentDtos { get; set; }
    }
}
