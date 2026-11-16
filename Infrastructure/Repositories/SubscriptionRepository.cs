using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubscriptionRepository(AppDbContext appDbContext) : ISubscriptionRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddSubscription(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        if (subscription == null)
            return false;

        _context.Subscriptions.Remove(subscription);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Subscription>> GetAllSubscriptions()
    {
        return await _context.Subscriptions.ToListAsync();
    }

    public async Task<Subscription> GetSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        return subscription!;
    }

    public async Task<bool> UpdateSubscription(Subscription subscription, int id)
    {
        var existing = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.CompanyId = subscription.CompanyId;
        existing.PlanType = subscription.PlanType;
        existing.MealsPerDay = subscription.MealsPerDay;
        existing.Price = subscription.Price;
        existing.StartDate = subscription.StartDate;
        existing.EndDate = subscription.EndDate;
        existing.IsActive = subscription.IsActive;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
