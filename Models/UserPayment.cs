using System;
namespace BangazonBE.Models;

public class UserPayment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PaymentId { get; set; }
    public PaymentType PaymentType { get; set; }
}

