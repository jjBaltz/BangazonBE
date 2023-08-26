using System;
namespace BangazonBE.Models;

public class PaymentType
{
    public int Id { get; set; }
    public string CardTypeName { get; set; }
    public int CardNumber { get; set; }
}

