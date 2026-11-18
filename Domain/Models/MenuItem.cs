namespace Domain.Models;

public class MenuItem
{
    public int Id { get; set; }
    public Menu? Menu { get; set; }
    public int MenuId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<OrderItem> OrderItems { get; set; } = new();
}
