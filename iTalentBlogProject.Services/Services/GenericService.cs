using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Core.Services;
using iTalentBlogProject.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace iTalentBlogProject.Services.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Where(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var hasProduct = _repository.GetByIdAsync(id);
            if (hasProduct != null)
            {
                throw new Exception($"{typeof(TEntity).Name}({id}) not Found");
            }

            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
