using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
