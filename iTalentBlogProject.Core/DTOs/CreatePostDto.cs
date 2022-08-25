using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class CreatePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentCaption { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
