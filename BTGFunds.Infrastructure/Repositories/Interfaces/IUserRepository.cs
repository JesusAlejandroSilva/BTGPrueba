using BTGFunds.Domain.Entities;

namespace BTGFunds.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task Update(User user);
    }
}
