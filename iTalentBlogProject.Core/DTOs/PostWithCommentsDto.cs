using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class PostWithCommentsDto : PostDto
    {
        public List<CommentDto> Comments { get; set; }
    }
}
