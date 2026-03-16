using BTGFunds.Domain.Entities;
using BTGFunds.Infrastructure.Mongo;
using BTGFunds.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace BTGFunds.Infrastructure.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoContext _context;

        public UserRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            await _context.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }
    }
}
