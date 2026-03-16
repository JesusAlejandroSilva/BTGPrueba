namespace BTGFunds.Domain.Entities
{
    public class User
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public decimal Balance { get; set; } = 500000;

        public string? NotificationPreference { get; set; }
    }
}
