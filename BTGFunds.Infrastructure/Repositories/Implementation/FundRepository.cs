using BTGFunds.Domain.Entities;
using BTGFunds.Infrastructure.Mongo;
using MongoDB.Driver;

namespace BTGFunds.Infrastructure.Repositories.Implementation
{
    public class FundRepository
    {
        private readonly MongoContext _context;

        public FundRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<List<Fund>> GetAll()
        {
            return await _context.Funds.Find(_ => true).ToListAsync();
        }

        public async Task<Fund> GetById(int id)
        {
            return await _context.Funds.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
