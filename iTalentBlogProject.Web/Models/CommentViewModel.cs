using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
    }
}
