using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fletnix.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<Subscription> GetCurrentSubscriptionAsync(string userId);
        Task<SubscriptionModel> GetSubscriptionModelAsync(int modelId);
        Task<Subscription> StartSubscriptionAsync(string userId, SubscriptionModel subscriptionModel);
        Task<List<SubscriptionModel>> GetSubscriptionModelsAsync();
    }
}