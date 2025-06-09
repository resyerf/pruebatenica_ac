using Domain.Entities.Loan;
namespace Domain.Interfaces.Repositories
{
    public interface ILoanDetailRepository
    {
        Task<LoanDetail> GetByLoanIdAsync(Guid id);
        Task Add(LoanDetail loan);
    }
}
