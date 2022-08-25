using iTalentBlogProject.Core.UnitOfWorks;
using iTalentBlogProject.Repository.Context;

namespace iTalentBlogProject.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly iTalentBlogContext _context;

        public UnitOfWork(iTalentBlogContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
