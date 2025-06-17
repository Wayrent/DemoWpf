using System;
using System.Collections.Generic;

namespace DemoWpf.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Floor { get; set; } = null!;

    public int Number { get; set; }

    public string Category { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<CleaningSchedule> CleaningSchedules { get; set; } = new List<CleaningSchedule>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RoomAccess> RoomAccesses { get; set; } = new List<RoomAccess>();
}
