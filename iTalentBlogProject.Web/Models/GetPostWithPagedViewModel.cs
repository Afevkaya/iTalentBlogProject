using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Web.Models;

namespace iTalentBlogProject.Web.Models
{
    public class GetPostWithPagedViewModel
    {
        public List<PostViewModel> Post { get; set; }
        public int totalCount { get; set; }
    }
}
