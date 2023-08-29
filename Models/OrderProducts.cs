﻿using System.ComponentModel.DataAnnotations;
namespace BangazonBE.Models;

public class OrderProduct
{
    public int OrderProductId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int OrderId { get; set; }
}