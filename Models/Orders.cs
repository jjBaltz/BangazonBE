using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public int StatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
