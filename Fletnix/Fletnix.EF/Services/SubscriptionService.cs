using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Fletnix.Domain;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;

namespace Fletnix.EF.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IBaseRepository<SubscriptionModel> _subscriptionModelRepository;
        private readonly IBaseRepository<Subscription> _subscriptionRepository;
        private readonly IBaseRepository<User> _userRepository;

        public SubscriptionService(
            IBaseRepository<SubscriptionModel> subscriptionModelRepository,
            IBaseRepository<Subscription> subscriptionRepository,
            IBaseRepository<User> userRepository)
        {
            _subscriptionModelRepository = subscriptionModelRepository;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        public Task<Subscription> GetCurrentSubscriptionAsync(string userId)
        {
            return _subscriptionRepository.Get(s => s.User.Id == userId).Include(s => s.SubscriptionModel).FirstOrDefaultAsync();
        }

        public Task<SubscriptionModel> GetSubscriptionModelAsync(int modelId)
        {
            return _subscriptionModelRepository.FirstOrDefaultAsync(m => m.Id == modelId);
        }

        public Task<List<SubscriptionModel>> GetSubscriptionModelsAsync()
        {
            return _subscriptionModelRepository.Get().Include("Options.SubscriptionOptionTemplate").ToListAsync();
        }

        public async Task<Subscription> StartSubscriptionAsync(string userId, SubscriptionModel subscriptionModel)
        {
            var subscription = _subscriptionRepository.Add(new Subscription
            {
                IsActive = true,
                SubscriptionStartDate = DateTime.UtcNow,
                SubscriptionModel = subscriptionModel,
                User = await _userRepository.FirstOrDefaultAsync(u => u.Id == userId)
            });
            await _subscriptionRepository.SaveChangesAsync();

            return subscription;
        }
    }
}