using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Core.Services
{
    public interface IGenericService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        IQueryable<TDto> Where(Expression<Func<TDto, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TDto, bool>> predicate);
        Task<TDto> GetByIdAsync(int id);
        Task AddAsync(TDto entity);
        Task UpdateAsync(TDto entity);
        Task RemoveAsync(TDto entity);
    }
}
