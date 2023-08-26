using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class PaymentType
{
    public int PaymentId { get; set; }
    public string CardTypeName { get; set; }
    public int CardNumber { get; set; }
}

