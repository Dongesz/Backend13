using System;
using System.Collections.Generic;

namespace RendszerKez.Models;

public partial class Order
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
