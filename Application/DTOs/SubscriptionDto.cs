namespace Application.DTOs;

public class SubscriptionDto
{
    public int CompanyId { get; set; }
    public string PlanType { get; set; } = null!;
    public int MealsPerDay { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}
