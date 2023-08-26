using System.ComponentModel.DataAnnotations;

namespace BangazonBE.Models;

public class User
{
    public int UserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    public bool IsSeller { get; set; }
    public List<Order> Orders { get; set; }
    public List<PaymentType> PaymentTypes { get; set; }
}