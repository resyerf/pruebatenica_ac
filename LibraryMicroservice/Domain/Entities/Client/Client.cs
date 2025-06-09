namespace Domain.Entities.Client
{
    public sealed class Client
    {
        public ClientId Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty    ;
        public string Address { get; set; } = string.Empty;
        public string Ubigeo { get; set; } = string.Empty;
        public bool IsBlacklisted { get; set; }
    }
}
