using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iTalentBlogProject.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        protected readonly iTalentBlogContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(iTalentBlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public  void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
