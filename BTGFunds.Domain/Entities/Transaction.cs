namespace BTGFunds.Domain.Entities
{
    public class Transaction
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public int FundId { get; set; }

        public string? Type { get; set; } 

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
