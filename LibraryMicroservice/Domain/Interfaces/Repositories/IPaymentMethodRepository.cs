using Domain.Entities.PaymentMethod;

namespace Domain.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> GetByIdAsync(Guid id);
        Task Add(PaymentMethod paymentMethod);
    }
}
