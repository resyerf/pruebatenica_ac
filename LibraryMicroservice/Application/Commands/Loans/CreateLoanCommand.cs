using Domain.Entities.Loan;
using MediatR;

namespace Application.Commands.Loans
{
    public record class CreateLoanCommand(
        int clientId, DateTime startDate, DateTime? endDate, string status, int? paymentMethodId
        ) : IRequest<Loan>;
}
