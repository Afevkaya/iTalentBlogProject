using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Core.Services;
using iTalentBlogProject.Core.UnitOfWorks;

namespace iTalentBlogProject.Services.Services
{
    public class PostService : GenericService<Post>, IPostService    {
        public PostService(IGenericRepository<Post> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
