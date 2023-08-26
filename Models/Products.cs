using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}