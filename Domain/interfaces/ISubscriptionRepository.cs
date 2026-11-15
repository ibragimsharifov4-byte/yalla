using Domain.Models;

namespace Domain.interfaces;

public interface ISubscriptionRepository
{
    Task<List<Subscription>> GetAllSubscriptions();
    Task<Subscription> GetSubscription(int id);
    Task<bool> AddSubscription(Subscription subscription);
    Task<bool> UpdateSubscription(Subscription subscription , int id);
    Task<bool> DeleteSubscription(int id);
}
