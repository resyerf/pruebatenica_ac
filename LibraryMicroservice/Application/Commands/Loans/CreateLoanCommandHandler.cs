using Domain.Entities.Book;
using Domain.Entities.Loan;
using Domain.Interfaces.Repositories;
using Domain.Primitives;
using MediatR;

namespace Application.Commands.Loans
{
    internal sealed class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Loan>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWorks _unitOfWork;
        private readonly ISender _mediator;
        public CreateLoanCommandHandler(ILoanRepository loanRepository, IUnitOfWorks unitOfWork, ISender mediator)
        {
            _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<Loan> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(
                new LoanId(Guid.NewGuid()),
                request.clientId,
                request.startDate,
                request.endDate,
                request.status,
                request.paymentMethodId
                );
            await _loanRepository.Add(loan);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            CreateLoanDetailCommand command = new CreateLoanDetailCommand(
                loan.Id,
                new BookCopyId(Guid.NewGuid())
            );

            await _mediator.Send(command);

            return loan;
        }
    }
}
