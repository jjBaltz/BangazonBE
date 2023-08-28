using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class UserPayment
{
    public int UserPaymentId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
}
