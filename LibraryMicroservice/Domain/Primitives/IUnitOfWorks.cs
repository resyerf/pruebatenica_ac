namespace Domain.Primitives
{
    public interface IUnitOfWorks
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
