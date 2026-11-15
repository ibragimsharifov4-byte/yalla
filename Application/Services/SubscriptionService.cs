using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class SubscriptionService(ISubscriptionRepository subscriptionRepository) : ISubscriptionService
{
    private ISubscriptionRepository _repository = subscriptionRepository;
    public async Task<ApiResponse<bool>> AddSubscription(SubscriptionDto subscription)
    {
        var model = new Subscription
        {
            CompanyId = subscription.CompanyId,
            PlanType = subscription.PlanType,
            MealsPerDay = subscription.MealsPerDay,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            IsActive = subscription.IsActive
        };
        var res = await _repository.AddSubscription(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteSubscription(int id)
    {
        var res = await _repository.DeleteSubscription(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Subscription not found" , false);
    }

    public async Task<ApiResponse<List<SubscriptionDto>>> GetAllSubscriptions()
    {
        var res = await _repository.GetAllSubscriptions();
        var list = res.Select(x => new SubscriptionDto
        {
            CompanyId = x.CompanyId,
            PlanType = x.PlanType,
            MealsPerDay = x.MealsPerDay,
            Price = x.Price,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            IsActive = x.IsActive
        }).ToList();
        return new ApiResponse<List<SubscriptionDto>>(HttpStatusCode.OK , "List of subscriptions" , list);
    }

    public async Task<ApiResponse<SubscriptionDto>> GetSubscription(int id)
    {
        var res = await _repository.GetSubscription(id);
        return res != null
        ? new ApiResponse<SubscriptionDto>(HttpStatusCode.OK , "Subscription found" , new SubscriptionDto
        {
            CompanyId = res.CompanyId,
            PlanType = res.PlanType,
            MealsPerDay = res.MealsPerDay,
            Price = res.Price,
            StartDate = res.StartDate,
            EndDate = res.EndDate,
            IsActive = res.IsActive
        })
        : new ApiResponse<SubscriptionDto>(HttpStatusCode.NotFound , "Subscription not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateSubscription(SubscriptionDto subscription , int id)
    {
        var model = new Subscription
        {
            CompanyId = subscription.CompanyId,
            PlanType = subscription.PlanType,
            MealsPerDay = subscription.MealsPerDay,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            IsActive = subscription.IsActive
        };
        var res = await _repository.UpdateSubscription(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Subscription not found" , false);
    }
}
