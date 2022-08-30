using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Web.Models;

namespace iTalentBlogProject.Web.Models
{
    public class PostWithCommentsViewModel : PostViewModel
    {
        public List<CommentViewModel> Comments { get; set; }
    }
}
