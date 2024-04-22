﻿using System;
using System.Collections.Generic;

namespace ACME.Database.EntityFramework.Models;

public partial class Price
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public double BasePrice { get; set; }

    public string ShopName { get; set; } = null!;

    public DateTime PriceDate { get; set; }

    public byte[]? Timestamp { get; set; }

    public virtual Product Product { get; set; } = null!;
}
