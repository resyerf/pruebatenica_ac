using Domain.Primitives;

namespace Domain.Entities.PaymentMethod
{
    public sealed class PaymentMethod : AggregateRoot
    {
        private PaymentMethod()
        {

        }

        public PaymentMethod(PaymentMethodId id, string nombre)
        {
            Id = id;
            this.nombre = nombre;
        }
        public PaymentMethodId Id { get; private set; }
        public string nombre { get; private set; } = string.Empty;
    }
}
