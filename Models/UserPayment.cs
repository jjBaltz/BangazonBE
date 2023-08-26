using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class UserPayment
{
    public int UPId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PaymentId { get; set; }
    public PaymentType PaymentType { get; set; }
}
