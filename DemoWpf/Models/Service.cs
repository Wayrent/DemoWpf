using System;
using System.Collections.Generic;

namespace DemoWpf.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();
}
