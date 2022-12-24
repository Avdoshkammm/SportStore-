using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportStoreStonks.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ArticleNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal DiscountAmount { get; set; }

    public int QuantityInStock { get; set; }

    public string Status { get; set; } = null!;

    public virtual string? ImagePath { get { return System.IO.Path.Combine(Environment.CurrentDirectory, $"images/jostick.jpg"); } }
}
