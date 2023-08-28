using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class OrderStatus
{
    public int OrderStatusId { get; set; }
    public string Status { get; set; }
}

