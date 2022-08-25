namespace iTalentBlogProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
