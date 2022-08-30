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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(iTalentBlogContext context) : base(context)
        {
        }
    }
}
