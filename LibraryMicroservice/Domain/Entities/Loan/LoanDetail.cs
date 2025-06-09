using Domain.Entities.Book;

namespace Domain.Entities.Loan
{
    public sealed class LoanDetail
    {
        public LoanDetail()
        {
        }
        public LoanDetail(LoanId loanId, BookCopyId bookCopyId)
        {
            LoanId = loanId;
            BookCopyId = bookCopyId;
        }
        public LoanId LoanId { get; set; }
        public BookCopyId BookCopyId { get; set; }
    }
}
