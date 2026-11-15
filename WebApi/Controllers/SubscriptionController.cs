using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController(ISubscriptionService subscriptionService) : ControllerBase
{
    private ISubscriptionService _service = subscriptionService;

    [HttpGet]
    public async Task<ApiResponse<List<SubscriptionDto>>> GetAllSubscriptions()
    {
        return await _service.GetAllSubscriptions();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<SubscriptionDto>> GetSubscription(int id)
    {
        return await _service.GetSubscription(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddSubscription(SubscriptionDto subscription)
    {
        return await _service.AddSubscription(subscription);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteSubscription(int id)
    {
        return await _service.DeleteSubscription(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateSubscription(SubscriptionDto subscription , int id)
    {
        return await _service.UpdateSubscription(subscription , id);
    }
}
