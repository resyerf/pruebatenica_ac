namespace Domain.Entities.Loan
{
    public sealed class Loan
    {
        private Loan()
        {
        }
        public Loan(LoanId id, int clientId, DateTime startDate, DateTime? endDate, string status, int? paymentMethodId)
        {
            Id = id;
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PaymentMethodId = paymentMethodId;
        }
        public LoanId Id { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
    }
}
