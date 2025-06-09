using Domain.Entities.Loan;

namespace Domain.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan> GetByIdAsync(Guid id);
        Task Add(Loan loan);
    }
}
