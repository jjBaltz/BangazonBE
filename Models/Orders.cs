using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
