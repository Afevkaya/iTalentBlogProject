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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
