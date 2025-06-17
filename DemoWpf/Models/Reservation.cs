using System;
using System.Collections.Generic;

namespace DemoWpf.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int? GuestId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Guest? Guest { get; set; }

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? Room { get; set; }
}
