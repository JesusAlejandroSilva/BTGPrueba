using BTGFunds.Domain.Entities;
using BTGFunds.Infrastructure.Mongo;
using MongoDB.Driver;

namespace BTGFunds.Infrastructure.Repositories.Implementation
{
    public class TransactionRepository
    {
        private readonly MongoContext _context;

        public TransactionRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task Create(Transaction transaction)
        {
            await _context.Transactions.InsertOneAsync(transaction);
        }

        public async Task<List<Transaction>> GetByUser(string userId)
        {
            return await _context.Transactions
                .Find(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
