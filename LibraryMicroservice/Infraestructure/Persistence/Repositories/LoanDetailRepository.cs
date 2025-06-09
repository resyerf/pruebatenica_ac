using Domain.Entities.Loan;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class LoanDetailRepository : ILoanDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public LoanDetailRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(LoanDetail loandDetail)
        {
            await _context.LoanDetails.AddAsync(loandDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<LoanDetail> GetByLoanIdAsync(Guid id) => await _context.LoanDetails.SingleOrDefaultAsync(l => l.LoanId.Value == id);
    }
}
