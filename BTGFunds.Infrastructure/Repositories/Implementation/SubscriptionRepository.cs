using BTGFunds.Domain.Entities;
using BTGFunds.Infrastructure.Mongo;
using MongoDB.Driver;

namespace BTGFunds.Infrastructure.Repositories.Implementation
{
    public class SubscriptionRepository
    {
        private readonly MongoContext _context;

        public SubscriptionRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task Create(Subscription sub)
        {
            await _context.Subscriptions.InsertOneAsync(sub);
        }

        public async Task<Subscription> GetById(string id)
        {
            return await _context.Subscriptions.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Subscription sub)
        {
            await _context.Subscriptions.ReplaceOneAsync(x => x.Id == sub.Id, sub);
        }
    }
}
