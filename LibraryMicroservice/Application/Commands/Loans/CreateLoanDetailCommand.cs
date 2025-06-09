using Domain.Entities.Book;
using Domain.Entities.Loan;
using MediatR;

namespace Application.Commands.Loans
{
    public  record class CreateLoanDetailCommand(
        LoanId loanId,
        BookCopyId bookCopyId
        ) : IRequest<LoanDetail>;
}
