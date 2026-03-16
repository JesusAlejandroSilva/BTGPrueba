using BTGFunds.Application.Interfaces;
using BTGFunds.Domain.Entities;
using BTGFunds.Infrastructure.Repositories.Implementation;
using BTGFunds.Infrastructure.Repositories.Interfaces;

namespace BTGFunds.Application.Services
{
    public class FundService
    {
        private readonly IUserRepository _userRepository;
        private readonly FundRepository _fundRepository;
        private readonly SubscriptionRepository _subscriptionRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly INotificationService _notificationService;

        public FundService(
            IUserRepository userRepository,
            FundRepository fundRepository,
            SubscriptionRepository subscriptionRepository,
            TransactionRepository transactionRepository,
            INotificationService notificationService)
        {
            _userRepository = userRepository;
            _fundRepository = fundRepository;
            _subscriptionRepository = subscriptionRepository;
            _transactionRepository = transactionRepository;
            _notificationService = notificationService;
        }

        public async Task Subscribe(string userId, int fundId)
        {
            var user = await _userRepository.GetById(userId);
            var fund = await _fundRepository.GetById(fundId);

            if (user.Balance < fund.MinimumAmount)
                throw new Exception($"No tiene saldo disponible para vincularse al fondo {fund.Name}");

            user.Balance -= fund.MinimumAmount;

            await _userRepository.Update(user);

            var subscription = new Subscription
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                FundId = fundId,
                Amount = fund.MinimumAmount,
                Active = true,
                CreatedAt = DateTime.UtcNow
            };

            await _subscriptionRepository.Create(subscription);

            await _transactionRepository.Create(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                FundId = fundId,
                Type = "OPEN",
                Amount = fund.MinimumAmount,
                Date = DateTime.UtcNow
            });

            await _notificationService.Notify(user, $"Suscripción exitosa al fondo {fund.Name}");
        }

        public async Task Cancel(string subscriptionId)
        {
            var sub = await _subscriptionRepository.GetById(subscriptionId);

            if (!sub.Active)
                throw new Exception("La suscripción ya está cancelada");

            var user = await _userRepository.GetById(sub.UserId);

            user.Balance += sub.Amount;

            sub.Active = false;

            await _userRepository.Update(user);
            await _subscriptionRepository.Update(sub);

            await _transactionRepository.Create(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                FundId = sub.FundId,
                Type = "CANCEL",
                Amount = sub.Amount,
                Date = DateTime.UtcNow
            });
        }

        public async Task<List<Transaction>> GetTransactions(string userId)
        {
            return await _transactionRepository.GetByUser(userId);
        }
    }
}