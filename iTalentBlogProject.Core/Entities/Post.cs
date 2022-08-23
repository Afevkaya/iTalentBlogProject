using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentCaption { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string PhotoUrl { get; set; }

    }
}
