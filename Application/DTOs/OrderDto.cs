namespace Application.DTOs;

public class OrderDto
{
    public int CompanyId { get; set; }
    public CompanyDto Company { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public decimal TotalAmount { get; set; }
}
