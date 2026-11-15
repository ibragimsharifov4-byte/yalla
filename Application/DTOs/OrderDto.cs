namespace Application.DTOs;

public class OrderDto
{
    public int CompanyId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public decimal TotalAmount { get; set; }
}
