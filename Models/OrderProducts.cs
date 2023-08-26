using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class OrderProduct
{
    public int OPId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}