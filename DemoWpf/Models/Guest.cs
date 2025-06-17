using System;
using System.Collections.Generic;

namespace DemoWpf.Models;

public partial class Guest
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public DateOnly CheckIn { get; set; }

    public DateOnly CheckOut { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RoomAccess> RoomAccesses { get; set; } = new List<RoomAccess>();
}
