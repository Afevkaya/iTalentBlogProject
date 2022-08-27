using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Repository.Context;

namespace iTalentBlogProject.Repository.Repositories
{
    public class CommentRepository: GenericRepository<Comment>, ICommentRepository 
    {
        public CommentRepository(iTalentBlogContext context) : base(context)
        {
        }
    }
}
