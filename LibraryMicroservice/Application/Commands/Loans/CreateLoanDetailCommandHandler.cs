using Domain.Entities.Loan;
using Domain.Interfaces.Repositories;
using Domain.Primitives;
using MediatR;

namespace Application.Commands.Loans
{
    internal sealed class CreateLoanDetailCommandHandler : IRequestHandler<CreateLoanDetailCommand, LoanDetail>
    {
        private readonly ILoanDetailRepository _loanDetailRepository;
        private readonly IUnitOfWorks _unitOfWork;

        public CreateLoanDetailCommandHandler(ILoanDetailRepository loanDetailRepository, IUnitOfWorks unitOfWork)
        {
            _loanDetailRepository = loanDetailRepository ?? throw new ArgumentNullException(nameof(loanDetailRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<LoanDetail> Handle(CreateLoanDetailCommand request, CancellationToken cancellationToken)
        {
            var loanDetail = new LoanDetail(
                request.loanId,
                request.bookCopyId
                );
            await _loanDetailRepository.Add(loanDetail);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return loanDetail;
        }
    }
}
