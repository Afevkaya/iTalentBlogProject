using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
