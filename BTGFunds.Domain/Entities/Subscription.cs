namespace BTGFunds.Domain.Entities
{
    public class Subscription
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public int FundId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }
    }
}
