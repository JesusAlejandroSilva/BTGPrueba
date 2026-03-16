namespace BTGFunds.Domain.Entities
{
    public class Fund
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal MinimumAmount { get; set; }

        public string? Category { get; set; }
    }
}
