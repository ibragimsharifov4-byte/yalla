using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface ISubscriptionService
{
    Task<ApiResponse<List<SubscriptionDto>>> GetAllSubscriptions();
    Task<ApiResponse<SubscriptionDto>> GetSubscription(int id);
    Task<ApiResponse<bool>> AddSubscription(SubscriptionDto subscription);
    Task<ApiResponse<bool>> UpdateSubscription(SubscriptionDto subscription , int id);
    Task<ApiResponse<bool>> DeleteSubscription(int id);
}
