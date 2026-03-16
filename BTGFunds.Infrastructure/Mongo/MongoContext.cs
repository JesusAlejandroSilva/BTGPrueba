using BTGFunds.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BTGFunds.Infrastructure.Mongo
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["Mongo:ConnectionString"]);
            _database = client.GetDatabase(configuration["Mongo:Database"]);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("users");

        public IMongoCollection<Fund> Funds => _database.GetCollection<Fund>("funds");

        public IMongoCollection<Subscription> Subscriptions => _database.GetCollection<Subscription>("subscriptions");

        public IMongoCollection<Domain.Entities.Transaction> Transactions => _database.GetCollection<Domain.Entities.Transaction>("transactions");
    }
}
