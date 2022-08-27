using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
