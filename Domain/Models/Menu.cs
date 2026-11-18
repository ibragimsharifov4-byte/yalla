namespace Domain.Models;

public class Menu
{
    public int Id { get; set; }
    public DateTime MenuDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<MenuItem> MenuItems { get; set; } = new();
}
