using System;
using System.Collections.Generic;

namespace DemoWpf.Models;

public partial class GuestService
{
    public int Id { get; set; }

    public int? ReservationsId { get; set; }

    public int? ServiceId { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public virtual Reservation? Reservations { get; set; }

    public virtual Service? Service { get; set; }
}
